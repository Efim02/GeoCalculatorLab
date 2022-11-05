namespace GCL.Droid
{
    using System.Linq;

    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;
    using Android.Util;

    using GCL.BL.Collection;
    using GCL.BL.Interface;
    using GCL.BL.Main;
    using GCL.DB.Main;
    using GCL.Droid.Main;
    using GCL.UI;
    using GCL.UI.Calculator;
    using GCL.UI.GitHub;
    using GCL.UI.Locator;
    using GCL.UI.Main;
    using GCL.UI.Shop;

    using Microsoft.EntityFrameworkCore;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using Platform = Xamarin.Essentials.Platform;

    [Activity(Label = "GCL", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                               ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : FormsAppCompatActivity
    {
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            var app = InitializeMainView();
            LoadApplication(app);

            Log.Debug("OnCreate", "вызывается при создании активности.");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug("OnDestroy", "вызывается перед окончательным уничтожением активности.");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug("OnPause", "вызывается когда активность ещё видна, но уже потеряла фокус.");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug("OnResume", "вызывается перед тем как активность начнёт полноценно работать.");
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug("OnStart", "вызывается когда активность уже создана и готова появиться на экране.");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug("OnStop", "вызывается при исчезновении активности с экрана.");
        }

        /// <summary>
        /// Создание главное представления.
        /// </summary>
        /// <returns> Представление с закладками:). </returns>
        private static TabbedMainPage CreateMainView()
        {
            var tabbedMainPage = new TabbedMainPage();

            var calculatorVM = new CalculatorVM();
            var calculatorView = new CalculatorView { BindingContext = calculatorVM, Title = "Калькулятор" };
            tabbedMainPage.Children.Add(calculatorView);

            var shopVM = new ShopVM();
            LoadProductsAsync(shopVM);
            var shopPage = new ShopPage { BindingContext = shopVM, Title = "Магазин" };
            tabbedMainPage.Children.Add(shopPage);

            var locatorVM = new LocatorVM();
            var locatorView = new LocatorView { BindingContext = locatorVM, Title = "Локатор" };
            tabbedMainPage.Children.Add(locatorView);

            var gitHubVM = new GitHubVM();
            var gitHubView = new GitHubView { BindingContext = gitHubVM, Title = "GitHub" };
            tabbedMainPage.Children.Add(gitHubView);

            return tabbedMainPage;
        }

        private static void InitializeDatabase()
        {
            // Применение миграций на имеющейся БД.
            var dbPath = Injector.Get<IPaths>().GetDbPath();
            using (var context = new PhoneDbContext(dbPath))
            {
                context.Database.Migrate();
            }
        }

        /// <summary>
        /// Инициализировать зависимости.
        /// </summary>
        private static void InitializeDependents()
        {
            Injector.RegisterSingleton<IPaths>(new Paths());
            Injector.Register<IDbFacade, DbFacade>();
            Injector.RegisterSingleton<IGpsManager>(new GpsManager());
        }

        /// <summary>
        /// Инициализация главного представления.
        /// </summary>
        /// <returns> Приложение. </returns>
        private static App InitializeMainView()
        {
            InitializeDependents();
            InitializeDatabase();

            var mainView = CreateMainView();
            return new App { MainPage = mainView };
        }

        /// <summary>
        /// Загрузить асинхронно продукты.
        /// </summary>
        /// <param name="shopVM"> Вью-модель магазина. </param>
        private static async void LoadProductsAsync(ShopVM shopVM)
        {
            var dbFacade = Injector.Get<IDbFacade>();
            var shopProducts = await dbFacade.ProductRepository.GetAll().ConfigureAwait(false);
            var shopProductVms = shopProducts.Select(p => ProductMapper.Map(p, shopVM));

            shopVM.ProductVms.AddRange(shopProductVms);
        }
    }
}
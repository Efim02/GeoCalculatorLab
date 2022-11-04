﻿namespace GCL.Droid
{
    using System.Linq;

    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;
    using Android.Util;

    using GCL.BL.Interface;
    using GCL.BL.Main;
    using GCL.DB.Collection;
    using GCL.DB.Main;
    using GCL.Droid.Main;
    using GCL.UI;
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
        /// Инициализировать зависимости.
        /// </summary>
        private static void InitializeDependents()
        {
            Injector.RegisterSingleton<IPaths>(new Paths());
            Injector.Register<IDbFacade, DbFacade>();
        }

        /// <summary>
        /// Инициализация главного представления.
        /// </summary>
        /// <returns> Приложение. </returns>
        private static App InitializeMainView()
        {
            InitializeDependents();

            // Применение миграций на имеющейся БД.
            var dbPath = Injector.Get<IPaths>().GetDbPath();
            using (var context = new PhoneDbContext(dbPath))
            {
                context.Database.Migrate();
            }

            var shopVM = new ShopVM();
            LoadProductsAsync(shopVM);
            var page = new ShopPage { BindingContext = shopVM };
            return new App { MainPage = page };
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
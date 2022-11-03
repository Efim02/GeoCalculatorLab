namespace GCL.UI
{
    using System.Collections.ObjectModel;

    using GCL.UI.Shop;

    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage { BindingContext = new CalculatorVM() };
            MainPage = new Shop.ShopPage
            {
                BindingContext = new ShopVM
                {
                    ProductVms = new ObservableCollection<ShopProductVM>
                    {
                        new ShopProductVM
                        {
                            Title = "Samsung Phone", Description = "Better is better mobile technology",
                            Price = 2500
                        },
                        new ShopProductVM
                        {
                            Title = "LG Phone", Description = "Maximum smoothness",
                            Price = 2000
                        },
                        new ShopProductVM
                        {
                            Title = "TCL Phone", Description = "Better by price",
                            Price = 1500
                        },
                    }
                }
            };
        }

        protected override void OnResume()
        {
            Log.Warning("App", "App: OnResume");
        }

        protected override void OnSleep()
        {
            Log.Warning("App", "App: OnSleep");
        }

        protected override void OnStart()
        {
            Log.Warning("App", "App: OnStart");
        }
    }
}
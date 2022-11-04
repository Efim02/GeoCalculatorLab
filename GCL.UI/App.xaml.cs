namespace GCL.UI
{
    using GCL.UI.Shop;

    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
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
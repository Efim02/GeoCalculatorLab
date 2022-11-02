namespace GCL.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;
    using Android.Util;

    using GCL.UI;

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
            LoadApplication(new App());

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
    }
}
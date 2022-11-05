namespace GCL.Droid.Services
{
    using System.Linq;

    using Android.App;
    using Android.Content;

    public static class ShopServiceUtils
    {
        /// <summary>
        /// Попытка проверить что сервис работает.
        /// </summary>
        /// <returns> TRUE - если сервис работает. </returns>
        public static bool IsShopServiceAvailable()
        {
            var activityManager = (ActivityManager)Application.Context.GetSystemService(Context.ActivityService);

            var services = activityManager.GetRunningServices(int.MaxValue);
            return services != null && services.Any(s => s.Service?.ClassName == ShopService.NAME);
        }
    }
}
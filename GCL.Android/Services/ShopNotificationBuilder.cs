namespace GCL.Droid.Services
{
    using Android.App;
    using Android.Content;
    using Android.OS;

    using AndroidX.Core.App;

    /// <summary>
    /// Построитель объекта уведомлений.
    /// </summary>
    public class ShopNotificationBuilder
    {
        public readonly NotificationManager NotificationService;

        private const string FOREGROUND_CHANNEL_ID = "8001";

        public ShopNotificationBuilder()
        {
            NotificationService = (NotificationManager)Application.Context.GetSystemService(Context.NotificationService);
        }

        /// <summary>
        /// Построить объект уведомлений.
        /// </summary>
        /// <param name="message"> Сообщение. </param>
        /// <returns> Уведомление. </returns>
        public Notification Build(string message)
        {
            // Чтобы выполнить какие-то действие определяем намеренье.
            //var intent = new Intent(Application.Context, typeof(MainActivity));
            //intent.AddFlags(ActivityFlags.SingleTop);
            //intent.PutExtra("Title", "Message");

            // Флаг для установки.
            //var pendingIntent =
                //PendingIntent.GetActivity(Application.Context, 0, intent, PendingIntentFlags.OneShot);

            var builder = new NotificationCompat.Builder(Application.Context, FOREGROUND_CHANNEL_ID)
                //.SetContentIntent(pendingIntent)
                .SetSmallIcon(Resource.Mipmap.icon_round)
                .SetDefaults((int)NotificationDefaults.Sound)
                //.SetOngoing(true)
                .SetContentText(message)
                .SetContentTitle("GCL Магазин");

            if (Android.OS.Build.VERSION.SdkInt < BuildVersionCodes.O)
                return builder.Build();

            // Building channel if API version is 26 or above
            var notificationChannel =
                new NotificationChannel(FOREGROUND_CHANNEL_ID, "Title", NotificationImportance.Default);
            notificationChannel.EnableLights(true);
            notificationChannel.EnableVibration(true);
            notificationChannel.SetShowBadge(true);
            notificationChannel.SetVibrationPattern(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 400 });

            builder.SetChannelId(FOREGROUND_CHANNEL_ID);
            NotificationService.CreateNotificationChannel(notificationChannel);

            return builder.Build();
        }
    }
}
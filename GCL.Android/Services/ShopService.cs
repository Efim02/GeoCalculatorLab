namespace GCL.Droid.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Util;

    using GCL.DB.Main;

    /// <summary>
    /// Сервис магазина.
    /// </summary>
    [Service(Name = NAME)]
    //  IsolatedProcess = true, Process = "com.imaginaryGenius.shopservice.notification_process"
    public class ShopService : Service
    {
        public const string NAME = "com.imaginaryGenius.shopService";

        public const int SERVICE_RUNNING_NOTIFICATION_ID = 8000;

        private CancellationTokenSource _cancellationService;

        /// <summary>
        /// Количество продуктов, когда последний раз смотрели в БД.
        /// </summary>
        private int _countProducts;

        /// <inheritdoc />
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        /// <inheritdoc />
        public override void OnDestroy()
        {
            _cancellationService?.Cancel();
            _cancellationService?.Dispose();

            Log.Debug(nameof(ShopService), "Destroy");

            base.OnDestroy();
        }

        /// <inheritdoc />
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Log.Debug(nameof(ShopService), "Started");

            Notify("Сервис магазина GCL запущен.");

            _cancellationService = new CancellationTokenSource();
            Work();

            return StartCommandResult.Sticky;
        }

        /// <summary>
        /// Вывести уведомление.
        /// </summary>
        /// <param name="message"> Сообщение. </param>
        private void Notify(string message)
        {
            var notificationBuilder = new ShopNotificationBuilder();
            var notification = notificationBuilder.Build(message);
            notificationBuilder.NotificationService.Notify(SERVICE_RUNNING_NOTIFICATION_ID, notification);
        }

        /// <summary>
        /// Работа длительной службы.
        /// </summary>
        private async void Work()
        {
            await Task.Delay(5000);

            while (true)
            {
                if (_cancellationService.IsCancellationRequested)
                    return;

                using (var dbFacade = new DbFacade())
                {
                    var products = await dbFacade.ProductRepository.GetAll();
                    if (_countProducts != products.Count)
                    {
                        Notify($"Количество продуктов: {products.Count}");
                        _countProducts = products.Count;
                    }
                }

                await Task.Delay(5000);
            }
        }
    }
}
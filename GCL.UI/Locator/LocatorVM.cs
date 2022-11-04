namespace GCL.UI.Locator
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GCL.BL.Interface;
    using GCL.BL.Main;
    using GCL.UI.Base;

    using Xamarin.Essentials;

    /// <summary>
    /// Вью-модель локатора.
    /// </summary>
    public class LocatorVM : BaseVM
    {
        /// <summary>
        /// Задержка для каждого итерации обновления местоположения в мс.
        /// </summary>
        private const int DELAY = 2000;

        /// <summary>
        /// Токен отмены для длительной операции обновления позиции.
        /// </summary>
        private readonly CancellationTokenSource _updateLocationToken;

        /// <inheritdoc cref="EnabledGps" />
        private bool _enabledGps;

        /// <inheritdoc cref="IsPermitted" />
        private bool _isPermitted;

        /// <inheritdoc cref="Location" />
        private Location _location;

        public LocatorVM()
        {
            var locatorPermissionRequester = new LocatorPermissionRequestCommand();
            locatorPermissionRequester.Execute(this);

            _updateLocationToken = new CancellationTokenSource();
            UpdateLocationAsync();
        }

        /// <summary>
        /// Высота.
        /// </summary>
        public string Altitude => Math.Round(Location?.Altitude ?? 0, 4).ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Включен ли GPS текст.
        /// </summary>
        public string IsEnabledGpsText { get; set; }

        /// <summary>
        /// Разрешено.
        /// </summary>
        public bool IsPermitted
        {
            get => _isPermitted;
            set
            {
                if (value == _isPermitted)
                    return;

                _isPermitted = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Широта.
        /// </summary>
        public string Latitude => Math.Round(Location?.Latitude ?? 0, 4).ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Долгота.
        /// </summary>
        public string Longitude => Math.Round(Location?.Longitude ?? 0, 4).ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Местоположение.
        /// </summary>
        private Location Location
        {
            get => _location;
            set
            {
                _location = value;

                OnPropertyChanged(nameof(Latitude));
                OnPropertyChanged(nameof(Longitude));
                OnPropertyChanged(nameof(Altitude));
            }
        }

        /// <summary>
        /// Проверить включен ли GPS.
        /// </summary>
        private bool CheckEnabledGps()
        {
            var gpsManager = Injector.Get<IGpsManager>();
            var enabledGps = gpsManager.IsEnabled();
            IsEnabledGpsText = enabledGps ? "GPS включен" : "GPS выключен";
            OnPropertyChanged(nameof(IsEnabledGpsText));

            return enabledGps;
        }

        /// <summary>
        /// Обновлять местоположение.
        /// </summary>
        private async void UpdateLocationAsync()
        {
            while (true)
            {
                if (_updateLocationToken.IsCancellationRequested)
                    return;

                if (CheckEnabledGps() && IsPermitted)
                {
                    var request = new GeolocationRequest();
                    Location = await Geolocation.GetLocationAsync(request, _updateLocationToken.Token);
                }

                await Task.Delay(DELAY);
            }
        }

        /// <summary>
        /// Отменить длительную операцию.
        /// </summary>
        ~LocatorVM()
        {
            _updateLocationToken.Cancel();
            _updateLocationToken.Dispose();
        }
    }
}
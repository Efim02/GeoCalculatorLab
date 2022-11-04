namespace GCL.Droid.Main
{
    using System;

    using Android.App;
    using Android.Content;
    using Android.Locations;

    using GCL.BL.Interface;

    /// <summary>
    /// GPS менеджер.
    /// </summary>
    public class GpsManager : IGpsManager, IDisposable
    {
        /// <summary>
        /// Менеджер Android для получения информации о системе.
        /// </summary>
        private readonly LocationManager _locationManager;

        public GpsManager()
        {
            _locationManager = (LocationManager)Application.Context.GetSystemService(Context.LocationService);
        }

        /// <inheritdoc />
        public bool IsEnabled()
        {
            return _locationManager!.IsProviderEnabled(LocationManager.GpsProvider);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _locationManager?.Dispose();
        }
    }
}
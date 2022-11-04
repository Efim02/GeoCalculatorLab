namespace GCL.UI.Locator
{
    using System.Threading.Tasks;

    using GCL.UI.Base;

    using Xamarin.Essentials;

    /// <summary>
    /// Команда которая запросит разрешение.
    /// </summary>
    public class LocatorPermissionRequestCommand : TypedAsyncBaseCommand<LocatorVM>
    {
        /// <summary>
        /// Запрос.
        /// </summary>
        /// <param name="locatorVM"> Вью-модель в которую установим результат. </param>
        protected override async Task Execute(LocatorVM locatorVM)
        {
            var status = await new Permissions.LocationWhenInUse().RequestAsync();
            locatorVM.IsPermitted = status == PermissionStatus.Granted;
        }
    }
}
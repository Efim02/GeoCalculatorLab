namespace GCL.UI.GitHub
{
    using System.Threading.Tasks;

    using GCL.UI.Base;

    using Xamarin.Essentials;

    /// <summary>
    /// Команда открыть в браузере, репозиторий.
    /// </summary>
    public class OpenBrowseRepositoryCommand : TypedAsyncBaseCommand<RepVM>
    {
        /// <inheritdoc />
        protected override async Task Execute(RepVM repVM)
        {
            await Launcher.OpenAsync(repVM.Url);
        }
    }
}
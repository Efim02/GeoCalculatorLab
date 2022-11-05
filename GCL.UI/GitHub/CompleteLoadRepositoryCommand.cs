namespace GCL.UI.GitHub
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using GCL.UI.Base;

    /// <summary>
    /// Догрузить полностью информацию по репозиторию.
    /// </summary>
    public class CompleteLoadRepositoryCommand : TypedAsyncBaseCommand<RepVM>
    {
        /// <inheritdoc />
        protected override async Task Execute(RepVM repVM)
        {
            var ownerVM = repVM.OwnerVM;
            using (var client = new HttpClient())
            {
                ownerVM.AvatarImageData = await client.GetByteArrayAsync(ownerVM.AvatarUrl);
            }
        }
    }
}
namespace GCL.UI.GitHub
{
    using System.Linq;
    using System.Threading.Tasks;

    using GCL.BL.Collection;
    using GCL.BL.GitHub;
    using GCL.BL.Http;
    using GCL.UI.Base;

    /// <summary>
    /// Команда поиска по репозиторию.
    /// </summary>
    public class SearchRepositoryCommand : TypedAsyncBaseCommand<string>
    {
        /// <summary>
        /// Вью-модель вкладки гитхаба.
        /// </summary>
        private readonly GitHubVM _gitHubVM;

        public SearchRepositoryCommand(GitHubVM gitHubVM)
        {
            _gitHubVM = gitHubVM;
        }

        /// <inheritdoc />
        protected override async Task Execute(string name)
        {
            const int numberPage = 1;
            const int maxResultsOnPage = 30;
            var searchUrl = GitHubUtils.GetRepSearchUrl(name, numberPage, maxResultsOnPage);

            using (var objectClient = new ObjectClient<GitPage>())
            {
                var gitPage = await objectClient.GetAsync(searchUrl);

                _gitHubVM.RepVms.Clear();
                var repVms = gitPage.Repositories.Select(GitMapper.Map);
                _gitHubVM.RepVms.AddRange(repVms);
            }
        }
    }
}
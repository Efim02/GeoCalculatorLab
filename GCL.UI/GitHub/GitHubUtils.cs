namespace GCL.UI.GitHub
{
    /// <summary>
    /// Вспомогательная утилита при работе с GitHub вкладкой.
    /// </summary>
    public static class GitHubUtils
    {
        /// <summary>
        /// Получить Url поиска по репозиториям в гитхабе. Url является Rest API запросом для получения инфы по репозиториям.
        /// </summary>
        /// <param name="name"> Название репозитория. </param>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="maxResultsOnPage"> Максимальное число результатов на странице. </param>
        /// <returns> Url. </returns>
        public static string GetRepSearchUrl(string name, int page, int maxResultsOnPage)
        {
            return "https://api.github.com/search/repositories?" +
                   $"q={name}&sort=updated&page={page}&per_page={maxResultsOnPage}";
        }
    }
}
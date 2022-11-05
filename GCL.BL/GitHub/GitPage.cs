namespace GCL.BL.GitHub
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Страница Git.
    /// </summary>
    public class GitPage
    {
        /// <summary>
        /// Репозитории.
        /// </summary>
        [JsonProperty("items")]
        public List<Rep> Repositories { get; set; }
    }
}
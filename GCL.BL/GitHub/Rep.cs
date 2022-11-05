namespace GCL.BL.GitHub
{
    using Newtonsoft.Json;

    /// <summary>
    /// Репозитория.
    /// </summary>
    public class Rep
    {
        /// <summary>
        /// Описание.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// ИД репозитория.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Владелец.
        /// </summary>
        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        /// <summary>
        /// Дата обновления.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdateDate { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        [JsonProperty("html_url")]
        public string Url { get; set; }
    }
}
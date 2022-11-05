namespace GCL.BL.GitHub
{
    using Newtonsoft.Json;

    /// <summary>
    /// Владелец репозитория.
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Адрес на аватар.
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; set; }
    }
}
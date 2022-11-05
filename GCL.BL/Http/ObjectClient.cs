namespace GCL.BL.Http
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    /// Клиент для выполнения запросов.
    /// </summary>
    /// <typeparam name="T"> Тип сущности, которую хотим получить. </typeparam>
    public class ObjectClient<T> : IDisposable
    {
        /// <summary>
        /// Заголовок с названием стандарта данных, в формате которого получим их.
        /// </summary>
        private readonly string _accept;

        /// <summary>
        /// Web клиент.
        /// </summary>
        private readonly HttpClient _httpClient;

        public ObjectClient()
        {
            // TODO Сделать через конструктор; по необходимости.
            _accept = "application/vnd.github+json";
            _httpClient = new HttpClient();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
        
        /// <summary>
        /// Получить сущность.
        /// </summary>
        /// <param name="url"> Адрес. </param>
        /// <typeparam name="T"> Тип сущности, которую хотим получить. </typeparam>
        /// <returns> Сущность. </returns>
        public async Task<T> GetAsync(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
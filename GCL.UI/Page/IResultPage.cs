namespace GCL.UI.Page
{
    /// <summary>
    /// Интерфейс для страниц которые имеют результат.
    /// </summary>
    public interface IResultPage
    {
        /// <summary>
        /// Результат выполнения страницы.
        /// </summary>
        bool IsSuccess { get; set; }
    }
}
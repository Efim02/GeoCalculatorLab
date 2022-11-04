namespace GCL.BL.Interface
{
    /// <summary>
    /// Интерфейс для работы с путями.
    /// </summary>
    public interface IPaths
    {
        /// <summary>
        /// Получить путь к базе данных.
        /// </summary>
        /// <returns> Путь к БД. </returns>
        string GetDbPath();
    }
}
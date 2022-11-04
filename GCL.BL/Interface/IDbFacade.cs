namespace GCL.BL.Interface
{
    using System;

    /// <summary>
    /// Фасад базы данных.
    /// </summary>
    public interface IDbFacade : IDisposable
    {
        /// <summary>
        /// Репозиторий продуктов магазина.
        /// </summary>
        IProductRepository ProductRepository { get; }
    }
}
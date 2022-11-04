namespace GCL.BL.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GCL.BL.Shop;

    /// <summary>
    /// Репозиторий продуктов.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Добавить продукт.
        /// </summary>
        Task Add(Product product);

        /// <summary>
        /// Изменить продукт.
        /// </summary>
        /// <param name="product"> Продукт. </param>
        Task Change(Product product);

        /// <summary>
        /// Удалить продукт.
        /// </summary>
        /// <param name="product"> Продукт. </param>
        Task Remove(Product product);

        /// <summary>
        /// Получить все.
        /// </summary>
        /// <returns> Продукты. </returns>
        Task<List<Product>> GetAll();
    }
}
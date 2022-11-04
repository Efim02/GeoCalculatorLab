namespace GCL.DB.Shop
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GCL.BL.Interface;
    using GCL.BL.Shop;

    using Microsoft.EntityFrameworkCore;

    using AppContext = Main.AppContext;

    /// <summary>
    /// Репозиторий продуктов.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Контекст приложения.
        /// </summary>
        private readonly AppContext _appContext;

        /// <summary>
        /// Репозиторий продуктов.
        /// </summary>
        /// <param name="appContext"> Контекст. </param>
        public ProductRepository(AppContext appContext)
        {
            _appContext = appContext;
        }

        /// <inheritdoc />
        public async Task Add(Product product)
        {
            await _appContext.Products.AddAsync(product).ConfigureAwait(false);
            await _appContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task Change(Product product)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<List<Product>> GetAll()
        {
            return await _appContext.Products.ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Remove(Product product)
        {
            _appContext.Products.Remove(product);
            await _appContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
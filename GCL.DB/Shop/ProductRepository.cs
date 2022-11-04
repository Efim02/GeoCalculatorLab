namespace GCL.DB.Shop
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GCL.BL.Interface;
    using GCL.BL.Shop;
    using GCL.DB.Main;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Репозиторий продуктов.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Контекст приложения.
        /// </summary>
        private readonly PhoneDbContext _phoneDbContext;

        /// <summary>
        /// Репозиторий продуктов.
        /// </summary>
        /// <param name="phoneDbContext"> Контекст. </param>
        public ProductRepository(PhoneDbContext phoneDbContext)
        {
            _phoneDbContext = phoneDbContext;
        }

        /// <inheritdoc />
        public async Task Add(Product product)
        {
            await _phoneDbContext.Products.AddAsync(product).ConfigureAwait(false);
            await _phoneDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task Change(Product product)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<List<Product>> GetAll()
        {
            return await _phoneDbContext.Products.ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Remove(Product product)
        {
            _phoneDbContext.Products.Remove(product);
            await _phoneDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
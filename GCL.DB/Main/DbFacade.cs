namespace GCL.DB.Main
{
    using GCL.BL.Interface;
    using GCL.BL.Main;
    using GCL.DB.Shop;

    /// <summary>
    /// Фасад базы данных.
    /// </summary>
    public sealed class DbFacade : IDbFacade
    {
        /// <summary>
        /// Контекст БД.
        /// </summary>
        private readonly PhoneDbContext _phoneDbContext;

        /// <inheritdoc cref="DbFacade" />
        public DbFacade()
        {
            var dbPath = Injector.Get<IPaths>().GetDbPath();
            _phoneDbContext = new PhoneDbContext(dbPath);

            ProductRepository = new ProductRepository(_phoneDbContext);
        }

        /// <summary>
        /// Репозиторий продуктов.
        /// </summary>
        public IProductRepository ProductRepository { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            _phoneDbContext?.Dispose();
        }
    }
}
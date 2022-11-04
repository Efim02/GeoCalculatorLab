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
        private readonly AppContext _appContext;

        /// <inheritdoc cref="DbFacade" />
        public DbFacade()
        {
            var dbPath = Injector.Get<IPaths>().GetDbPath();
            _appContext = new AppContext(dbPath);

            ProductRepository = new ProductRepository(_appContext);
        }

        /// <summary>
        /// Репозиторий продуктов.
        /// </summary>
        public IProductRepository ProductRepository { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            _appContext?.Dispose();
        }
    }
}
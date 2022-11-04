namespace GCL.DB.Main
{
    using GCL.BL.Shop;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Основной контекст БД для приложения.
    /// </summary>
    public sealed class AppContext : DbContext
    {
        /// <summary>
        /// Путь к файлу БД.
        /// </summary>
        private readonly string _path;

        public AppContext()
        {
        }

        /// <inheritdoc cref="AppContext" />
        /// <param name="path"> Путь к БД. </param>
        public AppContext(string path)
        {
            _path = path;
            Database.Migrate();
        }

        /// <summary>
        /// Продукты магазина.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName={_path}");
        }
    }
}
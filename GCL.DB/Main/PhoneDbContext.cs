namespace GCL.DB.Main
{
    using GCL.BL.Shop;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Основной контекст БД для приложения.
    /// </summary>
    public sealed class PhoneDbContext : DbContext
    {
        /// <summary>
        /// Путь к файлу БД.
        /// </summary>
        private readonly string _path;

        public PhoneDbContext()
        {
        }

        /// <inheritdoc cref="PhoneDbContext" />
        /// <param name="path"> Путь к БД. </param>
        public PhoneDbContext(string path)
        {
            _path = path;
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
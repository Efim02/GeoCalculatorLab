namespace GCL.BL.Shop
{
    /// <summary>
    /// Продукт.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id продукта.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Данные изображения.
        /// </summary>
        public byte[] ImageData { get; set; }
    }
}
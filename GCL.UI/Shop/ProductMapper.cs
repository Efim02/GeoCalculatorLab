namespace GCL.UI.Shop
{
    using GCL.BL.Shop;

    /// <summary>
    /// Продуктовый маппер.
    /// </summary>
    public static class ProductMapper
    {
        /// <summary>
        /// Смаппить вью-модель в модель.
        /// </summary>
        public static Product Map(ShopProductVM shopProductVM)
        {
            return new Product
            {
                Description = shopProductVM.Description,
                Price = shopProductVM.Price,
                Id = shopProductVM.Id,
                Title = shopProductVM.Title
            };
        }

        /// <summary>
        /// Смаппить модель в вью-модель.
        /// </summary>
        public static ShopProductVM Map(Product shopProduct, ShopVM shopVM)
        {
            return new ShopProductVM(shopVM)
            {
                Description = shopProduct.Description,
                Price = shopProduct.Price,
                Id = shopProduct.Id,
                Title = shopProduct.Title
            };
        }
    }
}
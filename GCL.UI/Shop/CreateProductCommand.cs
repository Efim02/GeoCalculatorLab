namespace GCL.UI.Shop
{
    using GCL.UI.Base;

    /// <summary>
    /// Команда создать продукт.
    /// </summary>
    public class CreateProductCommand : TypedBaseCommand<ShopPage>
    {
        /// <inheritdoc />
        protected override async void Execute(ShopPage shopPage)
        {
            var shopVM = (ShopVM)shopPage.BindingContext;
            var createProductPage = new CreateProductPage
            {
                BindingContext = new CreateProductVM(shopVM),
            };
            await shopPage.Navigation.PushModalAsync(createProductPage);
        }
    }
}
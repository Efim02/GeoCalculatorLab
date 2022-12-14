namespace GCL.UI.Shop
{
    using System.Threading.Tasks;

    using GCL.BL.Interface;
    using GCL.BL.Main;
    using GCL.UI.Base;

    using Xamarin.Forms;

    /// <summary>
    /// Команда создания продукта. Продукт будет добавлен в БД.
    /// </summary>
    public class CreateProductCommand : TypedAsyncBaseCommand<ShopProductVM>
    {
        /// <summary>
        /// Магазин.
        /// </summary>
        private readonly ShopVM _shopVM;

        public CreateProductCommand(ShopVM shopVM)
        {
            _shopVM = shopVM;
        }

        /// <inheritdoc />
        protected override async Task Execute(ShopProductVM productVM)
        {
            var dbFacade = Injector.Get<IDbFacade>();
            var product = ProductMapper.Map(productVM);
            await dbFacade.ProductRepository.Add(product).ConfigureAwait(false);

            productVM.Id = product.Id;
            _shopVM.ProductVms.Add(productVM);

            await Application.Current.MainPage.Navigation.PopModalAsync(true);
        }
    }
}
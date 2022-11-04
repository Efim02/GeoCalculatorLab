namespace GCL.UI.Shop
{
    using System.Threading.Tasks;

    using GCL.BL.Interface;
    using GCL.BL.Main;
    using GCL.UI.Base;

    using Xamarin.Forms;

    /// <summary>
    /// Команда удаления продукта.
    /// </summary>
    public class RemoveProductCommand : TypedAsyncBaseCommand<ShopProductVM>
    {
        /// <summary>
        /// Магазин.
        /// </summary>
        private readonly ShopVM _shopVM;

        public RemoveProductCommand(ShopVM shopVM)
        {
            _shopVM = shopVM;
        }

        /// <inheritdoc />
        protected override async Task Execute(ShopProductVM productVM)
        {
            var dbFacade = Injector.Get<IDbFacade>();
            var product = ProductMapper.Map(productVM);
            await dbFacade.ProductRepository.Remove(product).ConfigureAwait(false);

            _shopVM.ProductVms.Remove(productVM);

            await Application.Current.MainPage.Navigation.PopModalAsync(true);
        }
    }
}
namespace GCL.UI.Shop
{
    using System.Windows.Input;

    using GCL.UI.Base;
    using GCL.UI.Page;

    /// <summary>
    /// Вью-модель для создания продукта.
    /// </summary>
    public class CreateProductVM : BaseVM, IResultPage
    {
        /// <summary>
        /// Магазин.
        /// </summary>
        private readonly ShopVM _shopVM;

        /// <inheritdoc cref="IsSuccess" />
        private bool _isSuccess;

        public CreateProductVM(ShopVM shopVM)
        {
            _shopVM = shopVM;
            CancelCommand = new PopResultPageCommand(this, false);
            CompleteCommand = new PopResultPageCommand(this, true);

            ProductVM = new ShopProductVM();
        }

        /// <summary>
        /// Команда отмены создания.
        /// </summary>
        public ICommand CancelCommand { get; }

        /// <summary>
        /// Команда завершения создания.
        /// </summary>
        public ICommand CompleteCommand { get; }

        /// <summary>
        /// Продукт создаваемый.
        /// </summary>
        public ShopProductVM ProductVM { get; }

        /// <inheritdoc />
        public bool IsSuccess
        {
            get => _isSuccess;
            set
            {
                _isSuccess = value;
                if (_isSuccess)
                    _shopVM.ProductVms.Add(ProductVM);
            }
        }
    }
}
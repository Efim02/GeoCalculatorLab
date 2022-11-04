namespace GCL.UI.Shop
{
    using System;
    using System.Windows.Input;

    using GCL.UI.Base;
    using GCL.UI.Page;

    /// <summary>
    /// Вью-модель для создания продукта.
    /// </summary>
    public class CreateProductVM : BaseVM
    {
        public CreateProductVM(ShopVM shopVM)
        {
            CancelCommand = new PopPageCommand();
            CompleteCommand = new CreateProductCommand(shopVM);
            CapturePhotoCommand = new CapturePhotoCommand();

            ProductVM = new ShopProductVM(shopVM);
        }

        /// <summary>
        /// Команда отмены создания.
        /// </summary>
        public ICommand CancelCommand { get; }
        
        /// <summary>
        /// Команда создать фотографию.
        /// </summary>
        public ICommand CapturePhotoCommand { get; }

        /// <summary>
        /// Команда завершения создания.
        /// </summary>
        public ICommand CompleteCommand { get; }

        /// <summary>
        /// Продукт создаваемый.
        /// </summary>
        public ShopProductVM ProductVM { get; }
    }
}
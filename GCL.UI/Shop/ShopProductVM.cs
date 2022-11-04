namespace GCL.UI.Shop
{
    using System.IO;
    using System.Windows.Input;

    using GCL.UI.Base;

    using Xamarin.Forms;

    /// <summary>
    /// Продукт магазина.
    /// </summary>
    public class ShopProductVM : BaseVM
    {
        private byte[] _imageData;

        /// <inheritdoc cref="IsSelected" />
        private bool _isSelected;

        public ShopProductVM(ShopVM shopVM)
        {
            RemoveProductCommand = new RemoveProductCommand(shopVM);
        }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Путь к файлу с фотографией.
        /// </summary>
        public byte[] ImageData
        {
            get => _imageData;
            set
            {
                _imageData = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        /// <summary>
        /// Источник данных для фотографии.
        /// </summary>
        public ImageSource ImageSource => ImageData!=null 
            ? ImageSource.FromStream(() => new MemoryStream(ImageData))
            : null;

        /// <summary>
        /// Выделен ли элемент.
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Команда удалить продукт.
        /// </summary>
        public ICommand RemoveProductCommand { get; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }
    }
}
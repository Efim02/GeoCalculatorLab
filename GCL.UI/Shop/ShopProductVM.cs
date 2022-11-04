namespace GCL.UI.Shop
{
    using System.Windows.Input;

    using GCL.UI.Base;

    /// <summary>
    /// Продукт магазина.
    /// </summary>
    public class ShopProductVM : BaseVM
    {
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
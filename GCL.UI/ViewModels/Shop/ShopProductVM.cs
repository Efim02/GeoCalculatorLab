namespace GCL.UI.ViewModels.Shop
{
    /// <summary>
    /// Продукт магазина.
    /// </summary>
    public class ShopProductVM : BaseVM
    {
        /// <inheritdoc cref="IsSelected" />
        private bool _isSelected;

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

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
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Кол-во денег.
        /// </summary>
        public double Price { get; set; }
    }
}
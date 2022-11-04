namespace GCL.UI.Shop
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using GCL.UI.Base;

    /// <summary>
    /// Вью-модель магазина.
    /// </summary>
    public class ShopVM : BaseVM
    {
        private CustomerVM _currentCustomerVM;

        /// <inheritdoc cref="Message" />
        private string _message;

        /// <inheritdoc cref="SelectedProductVM" />
        private ShopProductVM _selectedProductVM;

        public ShopVM()
        {
            ProductVms = new ObservableCollection<ShopProductVM>();
            CreateCustomerCommand = new CreateCustomerCommand();
            CreateProductCommand = new OpenPageCreatingCommand();
        }

        /// <summary>
        /// Команда создать покупателя.
        /// </summary>
        public ICommand CreateCustomerCommand { get; }

        /// <summary>
        /// Команда создать покупателя.
        /// </summary>
        public ICommand CreateProductCommand { get; }

        /// <summary>
        /// Текущий покупатель.
        /// </summary>
        public CustomerVM CurrentCustomerVM
        {
            get => _currentCustomerVM;
            set
            {
                if (Equals(value, _currentCustomerVM))
                    return;
                _currentCustomerVM = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Сообщение.
        /// </summary>
        public string Message
        {
            get => _message;
            set
            {
                if (value == _message)
                    return;
                _message = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Продукты.
        /// </summary>
        public ObservableCollection<ShopProductVM> ProductVms { get; set; }

        /// <summary>
        /// Выбранный продукт.
        /// </summary>
        public ShopProductVM SelectedProductVM
        {
            get => _selectedProductVM;
            set
            {
                if (Equals(value, _selectedProductVM))
                    return;

                _selectedProductVM = value;
                BuyProduct();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Купить выбранный продукт.
        /// </summary>
        private void BuyProduct()
        {
            if (CurrentCustomerVM == null)
                return;

            if (CurrentCustomerVM.Money >= SelectedProductVM.Price)
            {
                Message = $"{CurrentCustomerVM.Name} приобрел {SelectedProductVM.Title}.";
                CurrentCustomerVM.Money -= SelectedProductVM.Price;
                ProductVms.Remove(SelectedProductVM);
                return;
            }

            Message = $"{CurrentCustomerVM.Name} не хватает " +
                      $"{SelectedProductVM.Price - CurrentCustomerVM.Money} приобрести продукт.";
        }
    }
}
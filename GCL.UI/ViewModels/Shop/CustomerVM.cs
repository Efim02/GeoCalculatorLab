namespace GCL.UI.ViewModels.Shop
{
    /// <summary>
    /// Вью-модель покупатель.
    /// </summary>
    public class CustomerVM : BaseVM
    {
        private double _money;
        private string _name;

        /// <summary>
        /// Количество денег.
        /// </summary>
        public double Money
        {
            get => _money;
            set
            {
                if (value.Equals(_money))
                    return;
                _money = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name)
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }
    }
}
namespace GCL.UI.ViewModels
{
    using System.Windows.Input;

    using GCL.UI.Commands;

    /// <summary>
    /// Вью-модель калькулятора.
    /// </summary>
    public class CalculatorVM : BaseVM
    {
        /// <inheritdoc cref="Sum" />
        private double _sum;

        public CalculatorVM()
        {
            Sum = 0;
            SumCommand = new SumCommand();
        }

        /// <summary>
        /// Сумма в тексте.
        /// </summary>
        public string SumText => $"Результат: {Sum}";

        /// <summary>
        /// Первое введенное значение.
        /// </summary>
        public double FirstValue { get; set; }

        /// <summary>
        /// Второе введенное значение.
        /// </summary>
        public double SecondValue { get; set; }

        /// <summary>
        /// Сумма.
        /// </summary>
        public double Sum
        {
            get => _sum;
            set
            {
                if (value.Equals(_sum))
                    return;

                _sum = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SumText));
            }
        }

        /// <summary>
        /// Команда сложения чисел.
        /// </summary>
        public ICommand SumCommand { get; }
    }
}
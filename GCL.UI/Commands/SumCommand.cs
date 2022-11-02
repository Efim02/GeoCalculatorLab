namespace GCL.UI.Commands
{
    using GCL.UI.ViewModels;

    /// <summary>
    /// Команда суммирования.
    /// </summary>
    public class SumCommand : TypedBaseCommand<CalculatorVM>
    {
        /// <inheritdoc />
        protected override void Execute(CalculatorVM calculatorVM)
        {
            calculatorVM.Sum = calculatorVM.FirstValue + calculatorVM.SecondValue;
        }
    }
}
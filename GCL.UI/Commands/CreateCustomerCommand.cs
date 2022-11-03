namespace GCL.UI.Commands
{
    using System;

    using GCL.UI.ViewModels.Shop;

    /// <summary>
    /// Команда создать покупателя.
    /// </summary>
    public class CreateCustomerCommand : TypedBaseCommand<ShopVM>
    {
        /// <inheritdoc />
        protected override void Execute(ShopVM shopVM)
        {
            var random = new Random();
            var customer = new CustomerVM
            {
                Name = $"Валера{random.Next(0, 10)}",
                Money = (int)(random.NextDouble() * 3000)
            };
            shopVM.CurrentCustomerVM = customer;
        }
    }
}
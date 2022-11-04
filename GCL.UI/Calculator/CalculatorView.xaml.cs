namespace GCL.UI.Calculator
{
    using System;

    using Xamarin.Forms;

    public partial class CalculatorView : ContentPage
    {
        public CalculatorView()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            var newButton = new Button
            {
                Text = "Не нужная кнопка",
            };

            StackLayout.Children.Add(newButton);
        }
    }
}
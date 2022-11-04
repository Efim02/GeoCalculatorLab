namespace GCL.UI.Page
{
    using GCL.UI.Base;

    using Xamarin.Forms;

    /// <summary>
    /// Команда вытащить открытую страницу, из стека навигации.
    /// </summary>
    public class PopPageCommand : BaseCommand
    {
        /// <inheritdoc />
        public override async void Execute(object _)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync(true);
        }
    }
}
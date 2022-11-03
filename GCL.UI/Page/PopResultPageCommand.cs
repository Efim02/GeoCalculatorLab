namespace GCL.UI.Page
{
    using GCL.UI.Base;

    using Xamarin.Forms;

    /// <summary>
    /// Команда вытащить открытую страницу, из стека навигации.
    /// </summary>
    public class PopResultPageCommand : BaseCommand
    {
        private readonly bool _result;
        private readonly IResultPage _resultPage;

        public PopResultPageCommand(IResultPage resultPage, bool result)
        {
            _resultPage = resultPage;
            _result = result;
        }

        /// <inheritdoc />
        public override async void Execute(object _)
        {
            _resultPage.IsSuccess = _result;
            await Application.Current.MainPage.Navigation.PopModalAsync(true);
        }
    }
}
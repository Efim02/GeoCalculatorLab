namespace GCL.UI.Control
{
    using System.Threading.Tasks;

    using Xamarin.Forms;

    /// <summary>
    /// Держатель окна сообщением.
    /// </summary>
    public class MessageViewHandler
    {
        private readonly MessageView _messageView;

        public MessageViewHandler(string message)
        {
            _messageView = new MessageView { BindingContext = new MessageVM(message) };
        }

        public async Task Open()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(_messageView);
        }

        public async Task Close()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
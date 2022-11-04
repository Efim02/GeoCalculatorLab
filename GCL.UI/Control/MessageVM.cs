namespace GCL.UI.Control
{
    using GCL.UI.Base;

    /// <summary>
    /// Вью-модель окна сообщения.
    /// </summary>
    public class MessageVM : BaseVM
    {
        public MessageVM(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Сообщение.
        /// </summary>
        public string Message { get; set; }
    }
}
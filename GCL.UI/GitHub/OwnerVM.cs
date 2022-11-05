namespace GCL.UI.GitHub
{
    using System.IO;

    using GCL.UI.Base;

    using Xamarin.Forms;

    /// <summary>
    /// Вью-модель владельца репозитория.
    /// </summary>
    public class OwnerVM : BaseVM
    {
        /// <inheritdoc cref="AvatarImageData" />
        private byte[] _avatarImageData;

        /// <summary>
        /// Байты фотографии.
        /// </summary>
        public byte[] AvatarImageData
        {
            get => _avatarImageData;
            set
            {
                if (Equals(value, _avatarImageData))
                    return;

                _avatarImageData = value;
                OnPropertyChanged(nameof(AvatarImageSource));
            }
        }

        /// <summary>
        /// Фотография. Аватар.
        /// </summary>
        public ImageSource AvatarImageSource => ImageSource.FromStream(() => new MemoryStream(AvatarImageData));

        /// <summary>
        /// Адрес на аватар.
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }
    }
}
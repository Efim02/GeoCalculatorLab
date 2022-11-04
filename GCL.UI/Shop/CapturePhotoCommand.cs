namespace GCL.UI.Shop
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using GCL.UI.Base;
    using GCL.UI.Control;

    using SixLabors.ImageSharp.Formats.Png;
    using SixLabors.ImageSharp.Processing;

    using Xamarin.Essentials;
    using Xamarin.Forms;

    using Image = SixLabors.ImageSharp.Image;

    /// <summary>
    /// Команда захвата фото.
    /// </summary>
    public class CapturePhotoCommand : TypedAsyncBaseCommand<ShopProductVM>
    {
        private const string PROCESS_IMAGE = "Обработка изображения.";

        /// <inheritdoc />
        protected override async Task Execute(ShopProductVM productVM)
        {
            var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
            {
                Title = $"{DateTime.Now:hh.mm.ss}"
            });
            if (photo == null)
                return;

            var messageHandler = new MessageViewHandler(PROCESS_IMAGE);
            await messageHandler.Open();

            using (var image = await Image.LoadAsync(photo.FullPath))
            using (var photoMemory = new MemoryStream())
            {
                image.Mutate(c => c.Resize(100, 100));
                await image.SaveAsync(photoMemory, new PngEncoder());

                productVM.ImageData = photoMemory.ToArray();
            }

            await messageHandler.Close();
        }
    }
}
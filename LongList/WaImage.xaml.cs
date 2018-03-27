using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace LongList
{
    public sealed partial class WaImage
    {
        public WaImage()
        {
            InitializeComponent();
        }

        public Message Message
        {
            get { return (Message)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(Message), typeof(WaImage), new PropertyMetadata(null, MessagePropertyChangedCallback));

        private static async void MessagePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as WaImage;
            if (sender != null)
            {
                await sender.UpdateImageAsync();
            }
        }

        private async Task UpdateImageAsync()
        {
            await NewMethod("StoreLogo.png");
            await Task.Delay(2000);
            await NewMethod("emoji.png");
        }

        private async Task NewMethod(string fileName)
        {
            var installationFolder = await Windows.Application­Model.Package.Current.InstalledLocation.GetFolderAsync("Assets");

            StorageFile storelogo = await installationFolder.GetFileAsync(fileName);

            using (IRandomAccessStream imagestram = await storelogo.OpenReadAsync())
            {
                var bitmapImage = new BitmapImage
                {
                    DecodePixelWidth = 200,
                    DecodePixelHeight = 200
                };
                await bitmapImage.SetSourceAsync(imagestram);

                image.Source = bitmapImage;
            }
        }
    }
}

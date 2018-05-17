using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ProjetoRussia.UWP.ViewModels;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjetoRussia.UWP.Views
{
    public sealed partial class TimesPage : Page
    {
        private TimesViewModel ViewModel => DataContext as TimesViewModel;

        public TimesPage()
        {
            InitializeComponent();
        }

        public string Teste()
        {
            return "";
        }

        public async Task<ImageSource> ConverteImagem(byte[] bandeira)
        {
            return await ImageFromBytes(bandeira);
        }
        public async Task<BitmapImage> ImageFromBytes(byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);
                await image.SetSourceAsync(stream);
            }
            return image;
        }
    }
}

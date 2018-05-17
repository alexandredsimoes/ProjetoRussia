using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjetoRussia.UWP.Helpers
{
    public class BinaryToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            var bitmapImage = new BitmapImage
            {
                DecodePixelHeight = 200
            };

            using (var stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes((byte[])value);
                    writer.StoreAsync().GetResults();

                    bitmapImage.SetSource(stream);

                    return bitmapImage;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
           

            return value;

            //using (var stream = new InMemoryRandomAccessStream())
            //{
            //    using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
            //    {
            //        writer.WriteBytes((byte[])value);
            //        writer.StoreAsync().GetResults();

            //        bitmapImage.SetSource(stream);

            //        return bitmapImage;
            //    }
            //}
        }        
    }
}

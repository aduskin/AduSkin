using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AduSkin.Utility.Media
{
    public class StreamObj
    {
        public static string ToString(Stream stream)
        {
            try { return new StreamReader(stream).ReadToEnd(); }
            catch { return ""; }
        }

        public static ImageSource ToImageSource(Stream stream)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();

                return bitmapImage;
            }
            catch { return null; }
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace AduSkin.Utility.Media
{
    /// <summary>
    /// 实用工具
    /// </summary>
    internal class Utility
    {
        /// <summary>
        /// Rgba转Hsba
        /// </summary>
        /// <param name="rgba"></param>
        /// <returns></returns>
        internal static HsbaColor RgbaToHsba(RgbaColor rgba)
        {
            int[] rgb = new int[] { rgba.R, rgba.G, rgba.B };
            Array.Sort(rgb);
            int max = rgb[2];
            int min = rgb[0];

            double hsbB = max / 255.0;
            double hsbS = max == 0 ? 0 : (max - min) / (double)max;
            double hsbH = 0;

            if (rgba.R == rgba.G && rgba.R == rgba.B)
            {

            }
            else
            {
                if (max == rgba.R && rgba.G >= rgba.B) hsbH = (rgba.G - rgba.B) * 60.0 / (max - min) + 0.0;
                else if (max == rgba.R && rgba.G < rgba.B) hsbH = (rgba.G - rgba.B) * 60.0 / (max - min) + 360.0;
                else if (max == rgba.G) hsbH = (rgba.B - rgba.R) * 60.0 / (max - min) + 120.0;
                else if (max == rgba.B) hsbH = (rgba.R - rgba.G) * 60.0 / (max - min) + 240.0;
            }

            return new HsbaColor(hsbH, hsbS, hsbB, rgba.A / 255.0);
        }

        /// <summary>
        /// Hsba转Rgba
        /// </summary>
        /// <param name="hsba"></param>
        /// <returns></returns>
        internal static RgbaColor HsbaToRgba(HsbaColor hsba)
        {
            double r = 0, g = 0, b = 0;
            int i = (int)((hsba.H / 60) % 6);
            double f = (hsba.H / 60) - i;
            double p = hsba.B * (1 - hsba.S);
            double q = hsba.B * (1 - f * hsba.S);
            double t = hsba.B * (1 - (1 - f) * hsba.S);
            switch (i)
            {
                case 0:
                    r = hsba.B;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = hsba.B;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = hsba.B;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = hsba.B;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = hsba.B;
                    break;
                case 5:
                    r = hsba.B;
                    g = p;
                    b = q;
                    break;
                default:
                    break;
            }
            return new RgbaColor((int)(255.0 * r), (int)(255.0 * g), (int)(255.0 * b), (int)(255.0 * hsba.A));
        }

        /*
        /// <summary>
        /// Bitmap转byte[]
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        internal static byte[] BitmapToByte(Bitmap bitmap)
        {

            byte[] bytes = new byte[bitmap.Width * bitmap.Height * 4];
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            Marshal.Copy(bitmapData.Scan0, bytes, 0, bytes.Length);
            bitmap.UnlockBits(bitmapData);
            return bytes;
        }

        /// <summary>
        /// 从BitmapByte中读取颜色
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        internal static int[] GetByteColor(byte[] buffer, int w, int x, int y)
        {
            int[] color = new int[] { 0, 0, 0, 0 };
            color[0] = buffer[x * 4 + y * w * 4 + 0];
            color[1] = buffer[x * 4 + y * w * 4 + 1];
            color[2] = buffer[x * 4 + y * w * 4 + 2];
            color[3] = buffer[x * 4 + y * w * 4 + 3];
            return color;
        }
        */


        /// <summary>
        /// 读取指定图片到内存
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static BitmapSource LoadImg(string path)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(path));
                bitmapImage.EndInit();

                return bitmapImage;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// BitmapImage转Bitmap
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <returns></returns>
        internal static Bitmap BitmapImageToBitmap(BitmapImage bitmapImage)
        {
            PixelFormat pp = PixelFormat.Format32bppArgb;
            Bitmap bmp = new Bitmap(bitmapImage.PixelWidth, bitmapImage.PixelHeight, pp);
            BitmapData data = bmp.LockBits(new Rectangle(System.Drawing.Point.Empty, bmp.Size), ImageLockMode.WriteOnly, pp);
            bitmapImage.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bmp.UnlockBits(data);
            return bmp;
        }

        /// <summary>
        /// Bitmap转BitmapSource
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        internal static BitmapSource BitmapToBitmapSource(Bitmap bitmap)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }




        /// <summary>
        /// 获取颜色亮度
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static int GetBrightness(int r,int g,int b)
        {
            return (int)((0.2126 * r + 0.7152 * g + 0.0722 * b) / 2.55);
        }
    }
}
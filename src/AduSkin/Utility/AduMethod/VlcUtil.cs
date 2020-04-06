using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AduSkin.Utility.AduMethod
{
   public class VlcUtil
   {
      /// <summary>
      /// 合成带水印的图片
      /// </summary>
      /// <param name="filePath">原始图片全路径</param>
      /// <param name="watermark">水印内容</param>
      /// <param name="foreground">水印颜色</param>
      /// <param name="rows">水印显示的行数</param>
      /// <param name="columns">水印显示的列数</param>
      /// <param name="fontSize">水印字体大小，该字体大小针对1080p的图片，方法内部会根据图片像素自动设定水印字体大小</param>
      /// <param name="opacity">水印透明度</param>
      /// <param name="angle">水印显示角度</param>
      public static void ScreenshotWithWatermark(string filePath, string watermark, Brush foreground, FontWeight fontWeight, int rows = 3, int columns = 3
          , double fontSize = 36, double opacity = 0.3, double angle = -20)
      {
         BitmapImage bgImage;

         //从流中读取图片，防止出现资源被占用的问题
         using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
         {
            FileInfo fi = new FileInfo(filePath);
            byte[] bytes = reader.ReadBytes((int)fi.Length);

            bgImage = new BitmapImage();
            bgImage.BeginInit();
            bgImage.StreamSource = new MemoryStream(bytes);
            bgImage.EndInit();
            bgImage.CacheOption = BitmapCacheOption.OnLoad;
         }

         RenderTargetBitmap composeImage = new RenderTargetBitmap(bgImage.PixelWidth, bgImage.PixelHeight, bgImage.DpiX, bgImage.DpiY, PixelFormats.Default);

         fontSize = GetFontSizeByPixel(bgImage.PixelHeight, fontSize);

         //设置水印文字效果：字体、颜色等
#if NETCOREAPP
         FormattedText signatureTxt = new FormattedText(watermark, CultureInfo.CurrentCulture, FlowDirection.LeftToRight
             , new Typeface(SystemFonts.MessageFontFamily, FontStyles.Normal, fontWeight, FontStretches.Normal), fontSize, foreground,
             VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);
#else
            FormattedText signatureTxt = new FormattedText(watermark, CultureInfo.CurrentCulture, FlowDirection.LeftToRight
                , new Typeface(SystemFonts.MessageFontFamily, FontStyles.Normal, fontWeight, FontStretches.Normal), fontSize, foreground);
#endif

         DrawingVisual drawingVisual = new DrawingVisual();
         DrawingContext drawingContext = drawingVisual.RenderOpen();
         drawingContext.DrawImage(bgImage, new Rect(0, 0, bgImage.Width, bgImage.Height));

         #region 设置水印的旋转角度及透明度，需要在绘制水印文本之前设置，否则不生效
         //x，y为水印旋转的中心点
         double centerX = (bgImage.Width - signatureTxt.Width) / 2;
         double centerY = (bgImage.Height - signatureTxt.Height) / 2;

         //设置水印透明度
         drawingContext.PushOpacity(opacity);
         //设置水印旋转角度
         drawingContext.PushTransform(new RotateTransform(angle, centerX, centerY));
         #endregion

         #region 绘制全屏水印
         double intervalX = bgImage.Width / columns; //水印水平间隔
         double intervalY = bgImage.Height / rows; //水印垂直间隔

         //水印绘制方向：从上往下，再从左到右
         for (double i = 0; i < bgImage.Width; i += intervalX)
         {
            for (double j = 0; j < bgImage.Height + intervalY; j += intervalY)
            {
               //奇偶行间隔绘制水印
               if ((j / intervalY) % 2 == 0)
               {
                  drawingContext.DrawText(signatureTxt, new Point(i, j));
               }
               else
               {
                  drawingContext.DrawText(signatureTxt, new Point(i + intervalX / 2, j));
               }
            }
         }
         #endregion

         drawingContext.Close();

         composeImage.Render(drawingVisual);

         PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
         bitmapEncoder.Frames.Add(BitmapFrame.Create(composeImage));

         //删除VLC生成的原始截图
         File.Delete(filePath);

         //将合成水印的截图保存到本地
         using (Stream stream = File.OpenWrite(filePath))
         {
            bitmapEncoder.Save(stream);
         }
         bgImage = null;
      }

      /// <summary>
      /// 合成带水印的图片
      /// </summary>
      /// <param name="filePath">原始图片全路径</param>
      /// <param name="watermark">水印内容</param>
      /// <param name="foreground">水印颜色</param>
      /// <param name="rows">水印显示的行数</param>
      /// <param name="columns">水印显示的列数</param>
      public static void ScreenshotWithWatermark(string filePath, string watermark, Brush foreground, int rows = 3, int columns = 3)
      {
         ScreenshotWithWatermark(filePath, watermark, foreground, FontWeights.Bold, rows, columns, 36);
      }

      /// <summary>
      /// 根据图片像素设定水印字体大小
      /// </summary>
      /// <param name="pixelHeight"></param>
      /// <param name="fontSize"></param>
      /// <returns></returns>
      private static double GetFontSizeByPixel(int pixelHeight, double fontSize)
      {
         double size = 20d;
         if (pixelHeight <= 240)
         {
            size = 7;
         }
         else if (pixelHeight > 240 && pixelHeight <= 480)
         {
            size = 14;
         }
         else if (pixelHeight > 480 && pixelHeight <= 720)
         {
            size = 28;
         }
         else
         {
            size = fontSize;
         }
         return size;
      }
   }
}
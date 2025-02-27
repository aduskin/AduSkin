using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using AduSkin.Utility.Element;

namespace AduSkin.Controls.Metro
{ 
   public class AduSliderVerifyCode : Control
   {
      #region private fields
      private Slider PART_Slider;
      private Path PART_Path;
      private Path PART_PathFix;
      private Canvas PART_Canvas;
      private Thumb PART_Thumb;
      #endregion
      static AduSliderVerifyCode()
      {
         ElementBase.DefaultStyle<AduSliderVerifyCode>(DefaultStyleKeyProperty);
      }
      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();

         this.PART_Slider = this.GetTemplateChild("PART_Slider") as Slider;
         this.PART_Path = this.GetTemplateChild("PART_Path") as Path;
         this.PART_PathFix = this.GetTemplateChild("PART_PathFix") as Path;
         this.PART_Canvas = this.GetTemplateChild("PART_Canvas") as Canvas;
         if (PART_Slider != null)
            PART_Slider.ValueChanged += Slider_ValueChanged;
      }

      public string ImageUri
      {
         get { return (string)GetValue(ImageUriProperty); }
         set { SetValue(ImageUriProperty, value); }
      }

      public static readonly DependencyProperty ImageUriProperty =
          DependencyProperty.Register("ImageUri", typeof(string), typeof(AduSliderVerifyCode), new PropertyMetadata(null, (p, d) =>
          {
             (p as AduSliderVerifyCode).Restart();
          }));

      public bool Result
      {
         get { return (bool)GetValue(ResultProperty); }
         set { SetValue(ResultProperty, value); }
      }

      public static readonly DependencyProperty ResultProperty =
          DependencyProperty.Register("Result", typeof(bool), typeof(AduSliderVerifyCode), new PropertyMetadata(false));

      public double ToleranceValue
      {
         get { return (double)GetValue(ToleranceValueProperty); }
         set { SetValue(ToleranceValueProperty, value); }
      }

      public static readonly DependencyProperty ToleranceValueProperty =
          DependencyProperty.Register("ToleranceValue", typeof(double), typeof(AduSliderVerifyCode), new PropertyMetadata(3.0));

      public ImageBrush BackgroundImage
      {
         get { return (ImageBrush)GetValue(BackgroundImageProperty); }
         set { SetValue(BackgroundImageProperty, value); }
      }

      public static readonly DependencyProperty BackgroundImageProperty =
          DependencyProperty.Register("BackgroundImage", typeof(ImageBrush), typeof(AduSliderVerifyCode));

      #region Routed Event
      public static readonly RoutedEvent ResultChangedEvent = EventManager.RegisterRoutedEvent("ResultChanged", RoutingStrategy.Bubble, typeof(EventHandler), typeof(AduSliderVerifyCode));
      public event EventHandler ResultChanged
      {
         add { AddHandler(ResultChangedEvent, value); }
         remove { RemoveHandler(ResultChangedEvent, value); }
      }
      void RaiseResultChanged(bool result)
      {
         var arg = new RoutedEventArgs(ResultChangedEvent, result);
         RaiseEvent(arg);
      }
      #endregion

      private double _width = 48;

      protected override void OnRender(DrawingContext drawingContext)
      {
         Restart();
      }
      public void Restart()
      {
         if (PART_Canvas == null || !PART_Canvas.IsVisible)
            return;
         Result = false;

         Random ran = new Random();
         double value = ran.Next((int)(PART_Canvas.ActualWidth - _width) / 3, (int)(PART_Canvas.ActualWidth - _width));
         SetTopCenter(PART_PathFix);
         SetLeft(PART_PathFix, value);

         BitmapImage image = GetBitmapImage();
         SetBackground(image);

         SetTopCenter(PART_Path);
         SetFill(PART_Path, image, value);

         PART_Slider.Value = 0;
         PART_Slider.Maximum = this.PART_Canvas.ActualWidth - _width;
      }

      private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         var track = PART_Slider.Template.FindName("PART_Track", PART_Slider) as Track;
         PART_Thumb = PART_Slider.Template.FindName("PART_Thumb", PART_Slider) as Thumb;
         var checkbox = PART_Thumb.Template.FindName("PART_CheckBox", PART_Thumb) as CheckBox;
         if (Math.Abs(Canvas.GetLeft(PART_Path) - Canvas.GetLeft(PART_PathFix)) <= ToleranceValue)
         {
            checkbox.IsChecked = Result = true;
            RaiseResultChanged(Result);
         }
         else
         {
            checkbox.IsChecked = Result = false;
            RaiseResultChanged(Result);
         }
         SetLeft(PART_Path, PART_Slider.Value);
      }

      private BitmapImage GetBitmapImage()
      {
         Random ran = new Random();
         int value = ran.Next(1, 3);

         BitmapImage image = new BitmapImage();
         image.BeginInit();
         image.UriSource = string.IsNullOrEmpty(ImageUri) ? new Uri($"pack://application:,,,/Images/TempCover/Temp{value}.jpg", UriKind.Absolute) : new Uri(ImageUri);
         image.DecodePixelWidth = (int)PART_Canvas.ActualWidth;
         image.DecodePixelHeight = (int)PART_Canvas.ActualHeight;
         image.EndInit();

         return image;
      }

      private void SetBackground(BitmapImage image)
      {
         ImageBrush ib = new ImageBrush();
         ib.Stretch = Stretch.UniformToFill;
         ib.ImageSource = image;
         BackgroundImage = ib;
      }

      private void SetFill(Shape element, BitmapImage image, double value)
      {
         ImageBrush ib = new ImageBrush();
         ib.AlignmentX = AlignmentX.Left;
         ib.AlignmentY = AlignmentY.Top;
         ib.ImageSource = image;
         ib.Viewbox = new Rect(value, (PART_Canvas.ActualHeight - PART_Path.ActualHeight) / 2, PART_Canvas.ActualWidth, PART_Path.ActualHeight);
         ib.ViewboxUnits = BrushMappingMode.Absolute; //按百分比设置宽高
         ib.TileMode = TileMode.None; //按百分比应该不会出现 image小于要切的值的情况
         ib.Stretch = Stretch.None;

         element.Fill = ib;
      }

      private void SetTopCenter(FrameworkElement element)
      {
         double top = (PART_Canvas.ActualHeight - element.ActualHeight) / 2;
         Canvas.SetTop(element, top);
      }

      private void SetLeft(FrameworkElement element, double left)
      {
         Canvas.SetLeft(element, left);
      }
   }

   public class RThumb : Thumb, IRThumb
   {
      private TouchDevice currentDevice = null;

      protected override void OnPreviewTouchDown(TouchEventArgs e)
      {
         this.ReleaseCurrentDevice();
         this.CaptureCurrentDevice(e);
      }

      protected override void OnPreviewTouchUp(TouchEventArgs e)
      {
         this.ReleaseCurrentDevice();
      }

      protected override void OnLostTouchCapture(TouchEventArgs e)
      {
         if (this.currentDevice != null)
            this.CaptureCurrentDevice(e);
      }

      private void ReleaseCurrentDevice()
      {
         if (this.currentDevice != null)
         {
            var temp = this.currentDevice;
            this.currentDevice = null;
            this.ReleaseTouchCapture(temp);
         }
      }

      private void CaptureCurrentDevice(TouchEventArgs e)
      {
         bool gotTouch = this.CaptureTouch(e.TouchDevice);
         if (gotTouch)
            this.currentDevice = e.TouchDevice;
      }
   }
   public interface IRThumb : IInputElement
   {
      event DragStartedEventHandler DragStarted;

      event DragDeltaEventHandler DragDelta;

      event DragCompletedEventHandler DragCompleted;

      event MouseButtonEventHandler MouseDoubleClick;
   }
}

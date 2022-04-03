using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AduSkin.Controls.Metro.Base
{
   public class AduButtonBase : Button
   {
      #region AduSkin
      public Geometry Icon
      {
         get { return (Geometry)GetValue(IconProperty); }
         set { SetValue(IconProperty, value); }
      }

      public static readonly DependencyProperty IconProperty =
          DependencyProperty.Register("Icon", typeof(Geometry), typeof(AduButtonBase));

      public double IconWidth
      {
         get { return (double)GetValue(IconWidthProperty); }
         set { SetValue(IconWidthProperty, value); }
      }

      public static readonly DependencyProperty IconWidthProperty =
          DependencyProperty.Register("IconWidth", typeof(double), typeof(AduButtonBase), new PropertyMetadata(20.0));

      public double IconHeight
      {
         get { return (double)GetValue(IconHeightProperty); }
         set { SetValue(IconHeightProperty, value); }
      }

      public static readonly DependencyProperty IconHeightProperty =
          DependencyProperty.Register("IconHeight", typeof(double), typeof(AduButtonBase), new PropertyMetadata(20.0));

      public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(AduButtonBase));
      /// <summary>
      /// 按钮四周圆角
      /// </summary>
      public CornerRadius CornerRadius
      {
         get { return (CornerRadius)GetValue(CornerRadiusProperty); }
         set { SetValue(CornerRadiusProperty, value); }
      }

      public double IconTextMargin
      {
         get { return (double)GetValue(IconTextMarginProperty); }
         set { SetValue(IconTextMarginProperty, value); }
      }

      public static readonly DependencyProperty IconTextMarginProperty =
          DependencyProperty.Register("IconTextMargin", typeof(double), typeof(AduButtonBase), new PropertyMetadata(0.0));
      #endregion
   }
}

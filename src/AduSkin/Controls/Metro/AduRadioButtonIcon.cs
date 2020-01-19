using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduRadioButtonIcon : RadioButton
   {
      public AduRadioButtonIcon()
      {
         Utility.Refresh(this);
      }
      static AduRadioButtonIcon()
      {
         ElementBase.DefaultStyle<AduRadioButtonIcon>(DefaultStyleKeyProperty);
      }

      #region AduSkin
      public static readonly DependencyProperty SelectColorProperty = DependencyProperty.Register("SelectColor"
            , typeof(Brush), typeof(AduRadioButtonIcon), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(238, 121, 111))));
      /// <summary>
      /// 选中时颜色
      /// </summary>
      public Brush SelectColor
      {
         get { return (Brush)GetValue(SelectColorProperty); }
         set { SetValue(SelectColorProperty, value); }
      }

      public Geometry Icon
      {
         get { return (Geometry)GetValue(IconProperty); }
         set { SetValue(IconProperty, value); }
      }

      public static readonly DependencyProperty IconProperty =
          DependencyProperty.Register("Icon", typeof(Geometry), typeof(AduRadioButtonIcon));

      public double IconWidth
      {
         get { return (double)GetValue(IconWidthProperty); }
         set { SetValue(IconWidthProperty, value); }
      }

      public static readonly DependencyProperty IconWidthProperty =
          DependencyProperty.Register("IconWidth", typeof(double), typeof(AduRadioButtonIcon), new PropertyMetadata(20.0));

      public double IconHeight
      {
         get { return (double)GetValue(IconHeightProperty); }
         set { SetValue(IconHeightProperty, value); }
      }

      public static readonly DependencyProperty IconHeightProperty =
          DependencyProperty.Register("IconHeight", typeof(double), typeof(AduRadioButtonIcon), new PropertyMetadata(20.0));

      #endregion
   }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduCheckButton : CheckBox
   {
      static AduCheckButton()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduCheckButton), new FrameworkPropertyMetadata(typeof(AduCheckButton)));
      }
      #region Path相关属性
      public static readonly DependencyProperty PathWidthProperty = DependencyProperty.Register("PathWidth"
          , typeof(double), typeof(AduCheckButton), new FrameworkPropertyMetadata(13d));
      /// <summary>
      /// Path的宽度
      /// </summary>
      public double PathWidth
      {
         get { return (double)GetValue(PathWidthProperty); }
         set { SetValue(PathWidthProperty, value); }
      }

      public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register("PathData"
          , typeof(Geometry), typeof(AduCheckButton));
      /// <summary>
      /// Path的Data
      /// </summary>
      public Geometry PathData
      {
         get { return (Geometry)GetValue(PathDataProperty); }
         set { SetValue(PathDataProperty, value); }
      }

      public static readonly DependencyProperty NormalPathColorProperty = DependencyProperty.Register("NormalPathColor"
          , typeof(Brush), typeof(AduCheckButton), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(40, 139, 225))));
      /// <summary>
      /// 正常显示时Path的颜色
      /// </summary>
      public Brush NormalPathColor
      {
         get { return (Brush)GetValue(NormalPathColorProperty); }
         set { SetValue(NormalPathColorProperty, value); }
      }

      public static readonly DependencyProperty MouseOverPathColorProperty = DependencyProperty.Register("MouseOverPathColor"
          , typeof(Brush), typeof(AduCheckButton), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(40, 139, 225))));
      /// <summary>
      /// 鼠标悬浮时Path的颜色
      /// </summary>
      public Brush MouseOverPathColor
      {
         get { return (Brush)GetValue(MouseOverPathColorProperty); }
         set { SetValue(MouseOverPathColorProperty, value); }
      }

      public static readonly DependencyProperty CheckedPathColorProperty = DependencyProperty.Register("CheckedPathColor"
         , typeof(Brush), typeof(AduCheckButton), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(40, 139, 225))));
      /// <summary>
      /// 鼠标悬浮时Path的颜色
      /// </summary>
      public Brush CheckedPathColor
      {
         get { return (Brush)GetValue(CheckedPathColorProperty); }
         set { SetValue(CheckedPathColorProperty, value); }
      }

      public static readonly DependencyProperty PressedPathColorProperty = DependencyProperty.Register("PressedPathColor"
          , typeof(Brush), typeof(AduCheckButton), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(36, 127, 207))));
      /// <summary>
      /// 鼠标按下时Path的颜色
      /// </summary>
      public Brush PressedPathColor
      {
         get { return (Brush)GetValue(PressedPathColorProperty); }
         set { SetValue(PressedPathColorProperty, value); }
      }

      public Brush DisabledPathColor
      {
         get { return (Brush)GetValue(DisabledPathColorProperty); }
         set { SetValue(DisabledPathColorProperty, value); }
      }

      public static readonly DependencyProperty DisabledPathColorProperty =
         DependencyProperty.Register("DisabledPathColor", typeof(Brush), typeof(AduCheckButton));

      #endregion
   }
}

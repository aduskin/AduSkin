using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduComboBox : ComboBox
   {
      public AduComboBox()
      {
         Utility.Refresh(this);
      }
      static AduComboBox()
      {
         ElementBase.DefaultStyle<AduComboBox>(DefaultStyleKeyProperty);
      }
      public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius"
          , typeof(CornerRadius), typeof(AduComboBox));
      /// <summary>
      /// 按钮四周圆角
      /// </summary>
      public CornerRadius CornerRadius
      {
         get { return (CornerRadius)GetValue(CornerRadiusProperty); }
         set { SetValue(CornerRadiusProperty, value); }
      }

      public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark"
            , typeof(string), typeof(AduComboBox));
      /// <summary>
      /// 文本输入框的水印
      /// </summary>
      public string Watermark
      {
         get { return (string)GetValue(WatermarkProperty); }
         set { SetValue(WatermarkProperty, value); }
      }

      public static readonly DependencyProperty ComBoxItemPanelBackgroundProperty = DependencyProperty.Register("ComBoxItemPanelBackground"
            , typeof(Brush), typeof(AduComboBox), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 255, 255))));
      /// <summary>
      /// 下拉列表背景色
      /// </summary>
      public Brush ComBoxItemPanelBackground
      {
         get { return (Brush)GetValue(ComBoxItemPanelBackgroundProperty); }
         set { SetValue(ComBoxItemPanelBackgroundProperty, value); }
      }

      public static readonly DependencyProperty ToggleButtonColorProperty = DependencyProperty.Register("ToggleButtonColor"
            , typeof(Brush), typeof(AduComboBox), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(238, 121, 111))));
      /// <summary>
      /// 下拉列表背景色
      /// </summary>
      public Brush ToggleButtonColor
      {
         get { return (Brush)GetValue(ToggleButtonColorProperty); }
         set { SetValue(ToggleButtonColorProperty, value); }
      }
   }
}
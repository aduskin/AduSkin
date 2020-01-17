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
   }
}
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
   }
}

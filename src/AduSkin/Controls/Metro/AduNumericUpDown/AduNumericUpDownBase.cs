
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
   public class AduNumericUpDownBase : MetroTextBox
   {
      static AduNumericUpDownBase()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduNumericUpDownBase), new FrameworkPropertyMetadata(typeof(AduNumericUpDownBase)));
      }

      public enum UpDownOrientationEnum
      {
         Vertical,
         Horizontal,
      }

      public static readonly DependencyProperty UpDownOrientationProperty = DependencyProperty.Register("UpDownOrientation"
          , typeof(UpDownOrientationEnum), typeof(MetroTextBox));
      /// <summary>
      /// 皮肤
      /// </summary>
      public UpDownOrientationEnum UpDownOrientation
      {
         get { return (UpDownOrientationEnum)GetValue(UpDownOrientationProperty); }
         set { SetValue(UpDownOrientationProperty, value); }
      }
   }
}

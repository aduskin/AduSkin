using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduRadioButton : RadioButton
   {
      static AduRadioButton()
      {
         ElementBase.DefaultStyle<AduRadioButton>(DefaultStyleKeyProperty);
      }
   }
}
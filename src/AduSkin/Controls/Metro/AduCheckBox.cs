using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduCheckBox : CheckBox
   {
      static AduCheckBox()
      {
         ElementBase.DefaultStyle<AduCheckBox>(DefaultStyleKeyProperty);
      }
   }
}
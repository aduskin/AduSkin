using AduSkin.Utility.Element;
using System.Windows.Controls.Primitives;

namespace AduSkin.Controls.Metro
{
   public class AduToggleButton : ToggleButton
   {
      static AduToggleButton()
      {
         ElementBase.DefaultStyle<AduToggleButton>(DefaultStyleKeyProperty);
      }
   }
}

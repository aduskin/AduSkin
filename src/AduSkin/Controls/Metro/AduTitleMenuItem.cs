using AduSkin.Utility.Element;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
   public class AduTitleMenuItem : MenuItem
   {
      public AduTitleMenuItem()
      {

      }
      static AduTitleMenuItem()
      {
         ElementBase.DefaultStyle<AduTitleMenuItem>(DefaultStyleKeyProperty);
      }
   }
}

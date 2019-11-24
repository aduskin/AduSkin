using AduSkin.Controls.Metro.Base;
using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{

   public class AduSysButton : AduButtonBase
   {
      public AduSysButton()
      {
         Utility.Refresh(this);
      }

      static AduSysButton()
      {
         ElementBase.DefaultStyle<AduSysButton>(DefaultStyleKeyProperty);
      }
   }
}
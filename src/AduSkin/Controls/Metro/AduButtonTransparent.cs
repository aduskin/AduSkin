using AduSkin.Controls.Metro.Base;
using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{

   public class AduButtonTransparent : AduButtonBase
   {
      public AduButtonTransparent()
      {
         Utility.Refresh(this);
      }

      static AduButtonTransparent()
      {
         ElementBase.DefaultStyle<AduButtonTransparent>(DefaultStyleKeyProperty);
      }
   }
}
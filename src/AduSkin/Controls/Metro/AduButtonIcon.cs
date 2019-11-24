using AduSkin.Controls.Metro.Base;
using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduButtonIcon : AduButtonBase
   {
      public AduButtonIcon()
      {
         Utility.Refresh(this);
      }

      static AduButtonIcon()
      {
         ElementBase.DefaultStyle<AduButtonIcon>(DefaultStyleKeyProperty);
      }

   }
}
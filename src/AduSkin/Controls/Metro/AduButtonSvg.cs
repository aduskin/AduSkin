using AduSkin.Controls.Metro.Base;
using AduSkin.Utility.Element;

namespace AduSkin.Controls.Metro
{

   public class AduButtonSvg : AduButtonBase
   {
      public AduButtonSvg()
      {
         Utility.Refresh(this);
      }

      static AduButtonSvg()
      {
         ElementBase.DefaultStyle<AduButtonSvg>(DefaultStyleKeyProperty);
      }
   }
}
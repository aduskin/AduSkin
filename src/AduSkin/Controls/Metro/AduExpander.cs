using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduExpander : Expander
   {
      static AduExpander()
      {
         ElementBase.DefaultStyle<AduExpander>(DefaultStyleKeyProperty);
      }
   }
}
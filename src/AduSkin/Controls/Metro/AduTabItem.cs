using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduTabItem : TabItem
   {
      static AduTabItem()
      {
         ElementBase.DefaultStyle<AduTabItem>(DefaultStyleKeyProperty);
      }
   }
}
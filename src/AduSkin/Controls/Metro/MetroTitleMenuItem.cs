using AduSkin.Utility.Element;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class MetroTitleMenuItem : MenuItem
   {
      static MetroTitleMenuItem()
      {
         ElementBase.DefaultStyle<MetroTitleMenuItem>(DefaultStyleKeyProperty);
      }
   }
}
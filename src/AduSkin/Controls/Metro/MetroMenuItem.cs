using AduSkin.Utility.Element;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
   public class MetroMenuItem : MenuItem
   {
      public MetroMenuItem()
      {

      }

      static MetroMenuItem()
      {
         ElementBase.DefaultStyle<MetroMenuItem>(DefaultStyleKeyProperty);
      }

      [Bindable(true)]
      [Category("Content")]
      [Localizability(LocalizationCategory.Label)]
      public new object Icon { get { return (object)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }
      public static readonly new DependencyProperty IconProperty = ElementBase.Property<MetroMenuItem, object>("IconProperty", null);
   }
}
using AduSkin.Utility.Element;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class MetroTitleMenuItem : MenuItem
   {
      public MetroTitleMenuItem()
      {

      }

      static MetroTitleMenuItem()
      {
         ElementBase.DefaultStyle<MetroTitleMenuItem>(DefaultStyleKeyProperty);
      }

      [Bindable(true)]
      [Category("Content")]
      [Localizability(LocalizationCategory.Label)]
      public new object Icon { get { return (object)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }
      public static readonly new DependencyProperty IconProperty = ElementBase.Property<MetroTitleMenuItem, object>("IconProperty", null);

   }
}
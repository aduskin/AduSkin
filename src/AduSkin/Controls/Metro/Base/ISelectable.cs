using System.Windows;

namespace AduSkin.Controls.Metro.Base
{
   public interface ISelectable
   {
      event RoutedEventHandler Selected;

      bool IsSelected { get; set; }
   }
}

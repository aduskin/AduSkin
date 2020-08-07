using System.Windows;

namespace AduSkin.Controls.Metro
{
   public interface ISelectable
   {
      event RoutedEventHandler Selected;

      bool IsSelected { get; set; }
   }
}

using System.Windows;

namespace AduSkin.Demo.Servers.Contracts
{
   public interface IWindow
   {
      event RoutedEventHandler Loaded;

      void Show();
   }
}

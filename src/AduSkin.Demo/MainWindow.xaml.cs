using AduSkin.Controls.Metro;
using AduSkin.Demo.Servers.Contracts;
using AduSkin.Demo.ViewModel;
using System.Windows;

namespace AduSkin.Demo
{
   public partial class MainWindow : MetroWindow, IWindow
   {
      public MainWindow(MainViewModel viewModel)
      {
         InitializeComponent();
         this.DataContext = viewModel;
         this.Closed += delegate { Application.Current.Shutdown(); };
      }
   }
}
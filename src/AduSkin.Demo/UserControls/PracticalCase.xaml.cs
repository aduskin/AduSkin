using AduSkin.Demo.Models;
using AduSkin.Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AduSkin.Demo.UserControls
{
   /// <summary>
   /// PracticalCase.xaml 的交互逻辑
   /// </summary>
   public partial class PracticalCase : UserControl
   {
      public PracticalCase()
      {
         InitializeComponent();
      }
      private void UIElement_OnMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
      {
         var sample = (ControlModel)((Border)sender).DataContext;
         var hvm = (PracticalCaseViewModel)DataContext;
         hvm.Content = (UserControl)Activator.CreateInstance(sample.Content);
         hvm.Title = sample.Title;
      }
   }
}

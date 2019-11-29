using AduSkin.Demo.Models;
using AduSkin.Demo.ViewModel.DemoViewModel;
using GalaSoft.MvvmLight.Command;
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
   /// SortGroup.xaml 的交互逻辑
   /// </summary>
   public partial class SortGroup : UserControl
   {
      public SortGroup()
      {
         InitializeComponent();
      }

      /// <summary>
      /// 命令Command
      /// </summary>
      public ICommand ToGroup => new RelayCommand<ChatUserModel>((e) =>
      {
         SortGroupViewModel vm= this.DataContext as SortGroupViewModel;
         vm.IsOpenSortList = false;
         ListBoxContact.UpdateLayout();
         ListBoxContact.AnimateScrollIntoView(e);
      });
   }
}

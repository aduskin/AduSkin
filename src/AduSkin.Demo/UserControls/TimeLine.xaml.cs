using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
   /// TimeLine.xaml 的交互逻辑
   /// </summary>
   public partial class TimeLine : UserControl
   {
      public TimeLine()
      {
         InitializeComponent();

         #region 时间轴
         ObservableCollection<Tuple<int, string, string>> listTimeLine = new ObservableCollection<Tuple<int, string, string>>();
         for (int i = 0; i < 5; i++)
         {
            listTimeLine.Add(new Tuple<int, string, string>(i, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "哈哈哈哈"));
         }
         AduTimeLine.ItemsSource = listTimeLine;
         #endregion
      }
   }
}

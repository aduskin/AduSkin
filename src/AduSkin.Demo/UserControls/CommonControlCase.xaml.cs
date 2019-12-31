using AduSkin.Utility.Media;
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
using System.Windows.Threading;

namespace AduSkin.Demo.UserControls
{
   /// <summary>
   /// CommonControlCase.xaml 的交互逻辑
   /// </summary>
   public partial class CommonControlCase : UserControl
   {
      public CommonControlCase()
      {
         InitializeComponent();

         color1.ColorChange += delegate
         {
            // 不要通过XAML来绑定颜色，无法获取到通知
            BorderBrush = color1.CurrentColor.OpaqueSolidColorBrush;
         };

         ts.IsChecked = true;
         #region 日期控件
         Calendar1.SelectedDate = Date3.SelectedDateTime = Date2.SelectedDateTime = Date1.SelectedDateTime = DateTime.Now;
         Date4.SelectedDateStart = Date5.SelectedDateStart = Date6.SelectedDateStart = DateTime.Now;
         Date4.SelectedDateEnd = Date5.SelectedDateEnd = Date6.SelectedDateEnd = DateTime.Now.AddDays(10);
         #endregion

         #region 富文本框
         rt1.Clear();

         rt1.AddLine("阅读模式");
         rt1.AddLine();
         rt1.AddLine("添加正常内容");
         rt1.AddLine("添加正常内容可点击", delegate { MessageBox.Show("你点击了我！"); });
         rt1.AddLine("添加自定义颜色内容", new RgbaColor(255, 0, 0, 255));
         rt1.AddLine("添加自定义颜色内容可点击", new RgbaColor(255, 0, 0, 255), delegate { MessageBox.Show("你点击了我！"); });

         rt3.Clear();

         rt3.AddLine("内容追加测试（不换行添加）");
         rt3.AddLine("http://www.baidu.com", "http://www.baidu.com");
         rt3.AddLine("中间的间距是Add(\"  \");方法添加的两个空格");
         rt3.AddLine();

         rt3.AddLine("追加正常内容");
         rt3.AddLine();
         rt3.Add("正常1");
         rt3.Add("   ");
         rt3.Add("正常2");
         rt3.Add("   ");
         rt3.Add("正常3");
         rt3.AddLine();

         rt3.AddLine("追加正常内容可点击");
         rt3.AddLine();
         rt3.Add("正常1", delegate { MessageBox.Show("你点击了我！"); });
         rt3.Add("   ");
         rt3.Add("正常2", delegate { MessageBox.Show("你点击了我！"); });
         rt3.Add("   ");
         rt3.Add("正常3", delegate { MessageBox.Show("你点击了我！"); });
         rt3.AddLine();

         rt3.AddLine("追加自定义颜色内容");
         rt3.AddLine();
         rt3.Add("颜色1", new RgbaColor(255, 0, 0, 255));
         rt3.Add("   ");
         rt3.Add("颜色2", new RgbaColor(0, 255, 0, 255));
         rt3.Add("   ");
         rt3.Add("颜色3", new RgbaColor(0, 0, 255, 255));
         rt3.AddLine();

         rt3.AddLine("追加自定义颜色内容可点击");
         rt3.AddLine();
         rt3.Add("颜色1", new RgbaColor(255, 0, 0, 255), delegate { MessageBox.Show("你点击了我！"); });
         rt3.Add("   ");
         rt3.Add("颜色2", new RgbaColor(0, 255, 0, 255), delegate { MessageBox.Show("你点击了我！"); });
         rt3.Add("   ");
         rt3.Add("颜色3", new RgbaColor(0, 0, 255, 255), delegate { MessageBox.Show("你点击了我！"); });
         rt3.AddLine();
         #endregion

         #region 进度条
         DispatcherTimer timer = new DispatcherTimer();
         timer.Tick += delegate
         {
            pb1.Value = pb1.Value + 1 > pb1.Maximum ? 0 : pb1.Value + 1;
            pb2.Value = pb2.Value + 1 > pb2.Maximum ? 0 : pb2.Value + 1;
            pb2.Title = pb2.Hint;
            pb2.Hint = null;
         };
         timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
         timer.Start();
         #endregion
      }
   }
}

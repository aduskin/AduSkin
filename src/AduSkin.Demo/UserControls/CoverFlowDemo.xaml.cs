using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace AduSkin.Demo.UserControls
{
   /// <summary>
   /// CoverFlowDemo.xaml 的交互逻辑
   /// </summary>
   public partial class CoverFlowDemo : UserControl
   {
      public CoverFlowDemo()
      {
         InitializeComponent();
         
         #region 轮播
         ObservableCollection<Models.Carousel> list = new ObservableCollection<Models.Carousel>();
         for (int i = 0; i < 5; i++)
         {
            list.Add(new Models.Carousel()
            {
               imgpath = "../Resources/aduskin.png",
               name = "AduSkin",
               info = "追求极致，永臻完美"
            });
         }
         this.CoverFlowMain.ItemsSource = list;
         CoverFlowMain.JumpTo(2);
         #endregion
      }
   }
}

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
   /// Carousel.xaml 的交互逻辑
   /// </summary>
   public partial class CarouselContainer : UserControl
   {
      public CarouselContainer()
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
         this.Carousels.ItemsSource = list;
         #endregion
      }
   }
}

using AduSkin.Controls.Metro;
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
   /// Expander.xaml 的交互逻辑
   /// </summary>
   public partial class ExpanderMenu : UserControl
   {
      public ExpanderMenu()
      {
         InitializeComponent();

         foreach (FrameworkElement fe in lists.Children)
         {
            if (fe is MetroExpander)
            {
               (fe as MetroExpander).Click += delegate (object sender, EventArgs e)
               {
                  if ((fe as MetroExpander).CanHide)
                  {
                     foreach (FrameworkElement fe1 in lists.Children)
                     {
                        if (fe1 is MetroExpander && fe1 != sender)
                        {
                           (fe1 as MetroExpander).IsExpanded = false;
                        }
                     }
                  }
               };
            }
         }
      }
   }
}

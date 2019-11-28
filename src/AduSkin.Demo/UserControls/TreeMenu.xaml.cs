using AduSkin.Demo.Models;
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
   /// TreeMenu.xaml 的交互逻辑
   /// </summary>
   public partial class TreeMenu : UserControl
   {
      public TreeMenu()
      {
         InitializeComponent();

         #region TreeView
         ObservableCollection<CompanyModel> TreeList = new ObservableCollection<CompanyModel>()
         {
                new CompanyModel()
                {
                    IsGrouping=true,
                    DisplayName="公司(3/7)",
                    Children=new ObservableCollection<CompanyModel>()
                    {
                        new CompanyModel(){
                            IsGrouping=true,
                            DisplayName="部门(2/4)",
                            Children=new ObservableCollection<CompanyModel>()
                            {
                                new CompanyModel(){
                                    IsGrouping=false,
                                    SurName="A",
                                    Name="AduSkin",
                                    Info="追求极致，臻于完美！",
                                    State="在线"
                                },
                                new CompanyModel(){
                                    IsGrouping=false,
                                    SurName="A",
                                    Name="AduSkin",
                                    Info="我要走向天空！",
                                    State="在线"
                                },
                                new CompanyModel(){
                                    IsGrouping=false,
                                    SurName="A",
                                    Name="AduSkin",
                                    Info="我要走向天空！",
                                    State="在线"
                                }
                            }
                        },
                         new CompanyModel(){
                            IsGrouping=true,
                            DisplayName="部门(2/4)",
                            Children=new ObservableCollection<CompanyModel>()
                            {
                                new CompanyModel(){
                                    IsGrouping=false,
                                    SurName="A",
                                    Name="AduSkin",
                                    Info="我要走向天空！",
                                    State="在线"
                                }
                            }
                        }, new CompanyModel(){
                            IsGrouping=true,
                            DisplayName="部门(2/4)",
                            Children=new ObservableCollection<CompanyModel>()
                            {
                                new CompanyModel(){
                                    IsGrouping=false,
                                    SurName="A",
                                    Name="AduSkin",
                                    Info="我要走向天空！",
                                    State="在线"
                                }
                            }
                        }
                    }
                }

            };
         TreeViewCompany.ItemsSource = TreeList;
         #endregion
      }
   }
}

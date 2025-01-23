using AduSkin.Demo.Data;
using AduSkin.Demo.Models;
using AduSkin.Demo.UserControls;
using AduSkin.Demo.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AduSkin.Demo.ViewModel
{
   public partial class MainViewModel : ObservableObject
   {
      public MainViewModel()
      {

      }

      private int _SelectedModularIndex;
      /// <summary>
      /// 属性.
      /// </summary>
      public int SelectedModularIndex
      {
         get { return _SelectedModularIndex; }
         set
         {
            SetProperty(ref _SelectedModularIndex, value);
            if (value == 2)
               MainBackground = new SolidColorBrush(Color.FromRgb(28, 64, 139));
            else if (value == 3)
               MainBackground = new SolidColorBrush(Color.FromRgb(250, 251, 252));
            else
               MainBackground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
         }
      }

      private SolidColorBrush _MainBackground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
      /// <summary>
      /// 属性.
      /// </summary>
      public SolidColorBrush MainBackground
      {
         get { return _MainBackground; }
         set { SetProperty(ref _MainBackground, value); }
      }
      /// <summary>
      /// 命令Command
      /// </summary>
      [RelayCommand]
      private void OpenClick(object e)
      {
         switch (e)
         {
            case "AduSkinDemo":
               new AduSkinDemo().Show();
               return;
         }
      }

      /// <summary>
      /// 常见控件
      /// </summary>
      private UserControl _CommonControlCase = new CommonControlCase();
      public UserControl CommonControlCase
      {
         get { return _CommonControlCase; }
         set { SetProperty(ref _CommonControlCase, value); }
      }
      /// <summary>
      /// 实用案例
      /// </summary>
      private UserControl _PracticalCase = new PracticalCase();
      public UserControl PracticalCase
      {
         get { return _PracticalCase; }
         set { SetProperty(ref _PracticalCase, value); }
      }
      /// <summary>
      /// 关于
      /// </summary>
      private UserControl _AduSkinAbout = new AduSkinAbout();
      public UserControl AduSkinAbout
      {
         get { return _AduSkinAbout; }
         set { SetProperty(ref _AduSkinAbout, value); }
      }
      /// <summary>
      /// 支持与赞助
      /// </summary>
      private UserControl _AduSkinSupport = new AduSkinSupport();
      public UserControl AduSkinSupport
      {
         get { return _AduSkinSupport; }
         set { SetProperty(ref _AduSkinSupport, value); }
      }
   }
}

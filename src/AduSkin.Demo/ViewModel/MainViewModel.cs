using AduSkin.Demo.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Demo.ViewModel
{
   public partial class MainViewModel : ObservableObject
   {
      public MainViewModel(IServiceProvider serviceProvider)
      {
         CommonControlCase= serviceProvider.GetRequiredService<CommonControlCase>();
         PracticalCase = serviceProvider.GetRequiredService<PracticalCase>();
         AduSkinAbout = serviceProvider.GetRequiredService<AduSkinAbout>();
         AduSkinSupport = serviceProvider.GetRequiredService<AduSkinSupport>();
      }

      /// <summary>
      /// 打开
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
      
      [ObservableProperty]
      private SolidColorBrush __mainBackground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
      /// <summary>
      /// 常见控件
      /// </summary>
      [ObservableProperty]
      private UserControl _commonControlCase;
      /// <summary>
      /// 实用案例
      /// </summary>
      [ObservableProperty]
      private UserControl _practicalCase;
      /// <summary>
      /// 关于
      /// </summary>
      [ObservableProperty]
      private UserControl _aduSkinAbout;
      /// <summary>
      /// 支持与赞助
      /// </summary>
      [ObservableProperty]
      private UserControl _aduSkinSupport;
   }
}

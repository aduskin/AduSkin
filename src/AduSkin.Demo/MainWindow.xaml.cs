using AduSkin.Controls;
using AduSkin.Controls.Metro;
using AduSkin.Controls.Metro.AduNotice;
using AduSkin.Demo.Models;
using AduSkin.Demo.UserControls;
using AduSkin.Demo.ViewModel;
using AduSkin.Demo.Views;
using AduSkin.Utility.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AduSkin.Demo
{
   public partial class MainWindow : MetroWindow
   {
      public MainWindow()
      {
         InitializeComponent();
        
         exit.Click += delegate { Close(); };
         Theme.ColorChange += delegate
         {
            // 不要通过XAML来绑定颜色，无法获取到通知
            BorderBrush = Theme.CurrentColor.OpaqueSolidColorBrush;
         };
      }
   }
}
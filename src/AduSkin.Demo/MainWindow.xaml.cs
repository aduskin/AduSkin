using AduSkin.Controls;
using AduSkin.Controls.Metro;
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
         this.Closed += delegate { Application.Current.Shutdown(); };
      }
   }
}
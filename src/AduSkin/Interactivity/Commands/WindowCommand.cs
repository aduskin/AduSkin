using AduSkin.Commen;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace AduSkin.Interactivity
{
   /// <summary>
   /// 窗口置顶
   /// </summary>
   public class TopMustWindowCommand : ICommand
   {
      public bool CanExecute(object parameter) => true;

      public void Execute(object parameter)
      {
         if (parameter is DependencyObject dependencyObject)
         {
            if (Window.GetWindow(dependencyObject) is Window window)
            {
               window.Topmost = !window.Topmost;
            }
         }
      }

      public event EventHandler CanExecuteChanged;
   }
   /// <summary>
   /// 关闭窗口
   /// </summary>
   public class CloseWindowCommand : ICommand
   {
      public bool CanExecute(object parameter) => true;

      public void Execute(object parameter)
      {
         if (parameter is DependencyObject dependencyObject)
         {
            if (Window.GetWindow(dependencyObject) is Window window)
            {
               window.Close();
            }
         }
      }

      public event EventHandler CanExecuteChanged;
   }
   /// <summary>
   /// 最小化窗口
   /// </summary>
   public class MinWindowCommand : ICommand
   {
      public bool CanExecute(object parameter) => true;

      public void Execute(object parameter)
      {
         if (parameter is DependencyObject dependencyObject)
         {
            if (Window.GetWindow(dependencyObject) is Window window)
            {
               window.WindowState = WindowState.Minimized;
            }
         }
      }

      public event EventHandler CanExecuteChanged;
   }
   /// <summary>
   /// 最大化/恢复
   /// </summary>
   public class ChangeWindowStateCommand : ICommand
   {
      public bool CanExecute(object parameter) => true;

      public void Execute(object parameter)
      {
         if (parameter is DependencyObject dependencyObject)
         {
            if (Window.GetWindow(dependencyObject) is Window window)
            {
               if (window.WindowState == WindowState.Maximized)
               {
                  window.WindowState = WindowState.Normal;
                  window.Padding = new Thickness(0);
               }

               else
               {
                  window.WindowState = WindowState.Maximized;
                  window.Padding = new Thickness(10);
               }
            }
         }
      }

      public event EventHandler CanExecuteChanged;
   }
   /// <summary>
   /// 关闭程序
   /// </summary>
   public class ShutdownAppCommand : ICommand
   {
      public bool CanExecute(object parameter) => true;

      public void Execute(object parameter) => Application.Current.Shutdown();

      public event EventHandler CanExecuteChanged;
   }
   /// <summary>
   /// 打开链接
   /// </summary>
   public class OpenLinkCommand : ICommand
   {
      public bool CanExecute(object parameter) => true;

      public void Execute(object parameter)
      {
         if (parameter is string link)
         {
            if (string.IsNullOrEmpty(link))
            {
               return;
            }
            link = link.Replace("&", "^&");
            try
            {
               Process.Start(new ProcessStartInfo("cmd", $"/c start {link}")
               {
                  UseShellExecute = false,
                  CreateNoWindow = true
               });
            }
            catch
            {
               // ignored
            }
         }
      }

      public event EventHandler CanExecuteChanged;
   }
   /// <summary>
   /// 主窗口置顶
   /// </summary>
   public class PushMainWindowTopCommand : ICommand
   {
      public bool CanExecute(object parameter) => true;

      public void Execute(object parameter)
      {
         if (Application.Current.MainWindow != null && Application.Current.MainWindow.Visibility != Visibility.Visible)
         {
            Application.Current.MainWindow.Show();
            var hwndSource = (HwndSource)PresentationSource.FromDependencyObject(Application.Current.MainWindow);
            if (hwndSource != null)
            {
               UnsafeNativeMethods.SetForegroundWindow(hwndSource.Handle);
            }
         }
      }

      public event EventHandler CanExecuteChanged;
   }
}
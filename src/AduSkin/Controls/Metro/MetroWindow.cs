using AduSkin.Themes;
using AduSkin.Utility.Element;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class MetroWindow : Window
   {
      private Button _btnMinimized, _btnMaximized, _btnNormal, _btnClose;
      public static readonly DependencyProperty IsSubWindowShowProperty = ElementBase.Property<MetroWindow, bool>("IsSubWindowShowProperty", false);
      public static readonly DependencyProperty MenuProperty = ElementBase.Property<MetroWindow, object>("MenuProperty", null);
      public static readonly new DependencyProperty BorderBrushProperty = ElementBase.Property<MetroWindow, Brush>("BorderBrushProperty");
      public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<MetroWindow, Brush>("TitleForegroundProperty");
      public static readonly DependencyProperty TitleFontSizeProperty = ElementBase.Property<MetroWindow, FontSizeConverter>("TitleFontSizeProperty");
      public static readonly DependencyProperty SysButtonColorProperty = ElementBase.Property<MetroWindow, Brush>("SysButtonColorProperty");

      public bool IsSubWindowShow { get { return (bool)GetValue(IsSubWindowShowProperty); } set { SetValue(IsSubWindowShowProperty, value); GoToState(); } }
      public object Menu { get { return GetValue(MenuProperty); } set { SetValue(MenuProperty, value); } }
      public new Brush BorderBrush { get { return (Brush)GetValue(BorderBrushProperty); } set { SetValue(BorderBrushProperty, value); BorderBrushChange(value); } }
      public Brush TitleForeground { get { return (Brush)GetValue(TitleForegroundProperty); } set { SetValue(TitleForegroundProperty, value); } }
      public Brush SysButtonColor { get { return (Brush)GetValue(SysButtonColorProperty); } set { SetValue(SysButtonColorProperty, value); } }
      public FontSizeConverter TitleFontSize { get { return (FontSizeConverter)GetValue(TitleFontSizeProperty); } set { SetValue(TitleFontSizeProperty, value); } }
      void BorderBrushChange(Brush brush)
      {
         if (IsLoaded)
         {
            Theme.Switch(this);
         }
      }

      void GoToState()
      {
         ElementBase.GoToState(this, IsSubWindowShow ? "Enabled" : "Disable");
      }

      public object ReturnValue { get; set; } //= null;
      public bool EscClose { get; set; } //= false;

      protected override void OnInitialized(EventArgs e)
      {
         base.OnInitialized(e);

         WindowStartupLocation = WindowStartupLocation.CenterScreen;
         AllowsTransparency = false;
         if (WindowStyle == WindowStyle.None)
         {
            WindowStyle = WindowStyle.SingleBorderWindow;
         }
      }

      public MetroWindow()
      {
         // 修复WindowChrome导致的窗口大小错误
         var sizeToContent = SizeToContent.Manual;
         Loaded += (ss, ee) =>
         {
            sizeToContent = SizeToContent;
         };
         ContentRendered += (ss, ee) =>
         {
            SizeToContent = SizeToContent.Manual;
            Width = ActualWidth;
            Height = ActualHeight;
            SizeToContent = sizeToContent;
         };

         KeyUp += delegate (object sender, KeyEventArgs e)
         {
            if (e.Key == Key.Escape && EscClose)
            {
               Close();
            }
         };
         StateChanged += delegate
           {
              if (ResizeMode == ResizeMode.CanMinimize || ResizeMode == ResizeMode.NoResize)
              {
                 if (WindowState == WindowState.Maximized)
                 {
                    WindowState = WindowState.Normal;
                 }
              }
           };
         Utility.Refresh(this);
      }

      /// <summary>在派生类中重写时，每当应用程序代码或内部进程调用 <see cref="FrameworkElement.ApplyTemplate" /> 时调用。</summary>
      public override void OnApplyTemplate()
      {
         _btnMinimized = (Button)GetTemplateChild("minimizedButton");
         _btnMaximized = (Button)GetTemplateChild("maximizedButton");
         _btnNormal = (Button)GetTemplateChild("normalButton");
         _btnClose = (Button)GetTemplateChild("closeButton");
         BindSystemButtonEvent();
         base.OnApplyTemplate();
      }

      static MetroWindow()
      {
         ElementBase.DefaultStyle<MetroWindow>(DefaultStyleKeyProperty);
      }

      /// <summary>给系统按钮绑定事件</summary>
      private void BindSystemButtonEvent()
      {
         _btnMinimized.Click += Minimized;
         _btnMaximized.Click += Maximized;
         _btnNormal.Click += Normal;
         _btnClose.Click += Close;
      }

      /// <summary>窗口最小化按钮事件</summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Minimized(object sender, RoutedEventArgs e)
      {
         GetWindow(sender as FrameworkElement).WindowState = WindowState.Minimized;
      }

      /// <summary>窗口最大化按钮事件</summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Maximized(object sender, RoutedEventArgs e)
      {
         GetWindow(sender as FrameworkElement).WindowState = WindowState.Maximized;
      }

      /// <summary>还原窗口按钮事件</summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Normal(object sender, RoutedEventArgs e)
      {
         Window.GetWindow(sender as FrameworkElement).WindowState = WindowState.Normal;
      }

      /// <summary>关闭窗口按钮事件</summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Close(object sender, RoutedEventArgs e)
      {
         Window.GetWindow(sender as FrameworkElement).Close();
      }
   }
}
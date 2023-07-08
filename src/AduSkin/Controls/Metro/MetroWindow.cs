using AduSkin.Interactivity;
using AduSkin.Themes;
using AduSkin.Utility.Element;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   /// <summary>
   /// MetroWindow窗口
   /// </summary>
   [TemplatePart(Name = "PART_MinimizedButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_MaximizedButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_NormalButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
   public class MetroWindow : Window
   {
      /// <summary>
      /// 系统控件命名
      /// </summary>
      private const string MinimizedButton = "PART_MinimizedButton";
      private const string MaximizedButton = "PART_MaximizedButton";
      private const string NormalButton = "PART_NormalButton";
      private const string CloseButton = "PART_CloseButton";
      /// <summary>
      /// 系统按钮
      /// </summary>
      private Button _MinimizedButton;
      private Button _MaximizedButton;
      private Button _NormalButton;
      private Button _CloseButton;

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
         
      }

      static MetroWindow()
      {
         ElementBase.DefaultStyle<MetroWindow>(DefaultStyleKeyProperty);
      }

      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();

         _MinimizedButton = GetTemplateChild(MinimizedButton) as Button;
         _MaximizedButton = GetTemplateChild(MaximizedButton) as Button;
         _NormalButton = GetTemplateChild(NormalButton) as Button;
         _CloseButton = GetTemplateChild(CloseButton) as Button;

         if (_MinimizedButton != null)
            _MinimizedButton.Click += delegate { this.WindowState = WindowState.Minimized; };
         if (_MaximizedButton != null)
            _MaximizedButton.Click += delegate { this.WindowState = WindowState.Maximized;  };
         if (_NormalButton != null)
            _NormalButton.Click += delegate { this.WindowState = WindowState.Normal; };
         if (_CloseButton != null)
            _CloseButton.Click += delegate { this.Close(); };
      }

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

      public static readonly DependencyProperty IsSubWindowShowProperty = ElementBase.Property<MetroWindow, bool>("IsSubWindowShowProperty", false);
      public static readonly DependencyProperty MenuProperty = ElementBase.Property<MetroWindow, object>("MenuProperty", null);
      public static readonly new DependencyProperty BorderBrushProperty = ElementBase.Property<MetroWindow, Brush>("BorderBrushProperty");
      public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<MetroWindow, Brush>("TitleForegroundProperty");
      public static readonly DependencyProperty TitleFontSizeProperty = ElementBase.Property<MetroWindow, FontSizeConverter>("TitleFontSizeProperty");
      public static readonly DependencyProperty SysButtonColorProperty = ElementBase.Property<MetroWindow, Brush>("SysButtonColorProperty");

      public bool IsSubWindowShow { get { return (bool)GetValue(IsSubWindowShowProperty); } set { SetValue(IsSubWindowShowProperty, value); GoToState(); } }
      public object Menu { get { return GetValue(MenuProperty); } set { SetValue(MenuProperty, value); } }
      public new Brush BorderBrush { get { return (Brush)GetValue(BorderBrushProperty); } set { SetValue(BorderBrushProperty, value);} }
      public Brush TitleForeground { get { return (Brush)GetValue(TitleForegroundProperty); } set { SetValue(TitleForegroundProperty, value); } }
      public Brush SysButtonColor { get { return (Brush)GetValue(SysButtonColorProperty); } set { SetValue(SysButtonColorProperty, value); } }
      public FontSizeConverter TitleFontSize { get { return (FontSizeConverter)GetValue(TitleFontSizeProperty); } set { SetValue(TitleFontSizeProperty, value); } }

      void GoToState()
      {
         ElementBase.GoToState(this, IsSubWindowShow ? "Enabled" : "Disable");
      }

      public object ReturnValue { get; set; } //= null;
      public bool EscClose { get; set; } //= false;

      
   }
}
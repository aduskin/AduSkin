using AduSkin.Themes;
using AduSkin.Utility.Element;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;

namespace AduSkin.Controls.Metro
{
   [TemplatePart(Name = "PART_MinimizedButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_MaximizedButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_NormalButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
   /// <summary>
   /// AduWindow窗口
   /// </summary>
   public partial class AduWindow : Window
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

      public AduWindow()
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

      static AduWindow()
      {
         ElementBase.DefaultStyle<AduWindow>(DefaultStyleKeyProperty);
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
            _MaximizedButton.Click += delegate { this.WindowState = WindowState.Maximized; this.Padding = new Thickness(10); };
         if (_NormalButton != null)
            _NormalButton.Click += delegate { this.WindowState = WindowState.Normal; this.Padding = new Thickness(0); };
         if (_CloseButton != null)
            _CloseButton.Click += delegate { this.Close(); };
      }

      public static readonly DependencyProperty IsSubWindowShowProperty = ElementBase.Property<AduWindow, bool>("IsSubWindowShowProperty", false);
      public static readonly DependencyProperty MenuProperty = ElementBase.Property<AduWindow, object>("MenuProperty", null);
      public static readonly new DependencyProperty BorderBrushProperty = ElementBase.Property<AduWindow, Brush>("BorderBrushProperty");
      public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<AduWindow, Brush>("TitleForegroundProperty");
      public static readonly DependencyProperty TitleFontSizeProperty = ElementBase.Property<AduWindow, FontSizeConverter>("TitleFontSizeProperty");
      public static readonly DependencyProperty SysButtonColorProperty = ElementBase.Property<AduWindow, Brush>("SysButtonColorProperty");
      public static readonly DependencyProperty SysButtonVisibleProperty = ElementBase.Property<AduWindow, Visibility>("SysButtonVisibleProperty");
      public static readonly DependencyProperty SysButtonMarginProperty = ElementBase.Property<AduWindow, Thickness>("SysButtonMarginProperty");

      public bool IsSubWindowShow { get { return (bool)GetValue(IsSubWindowShowProperty); } set { SetValue(IsSubWindowShowProperty, value); GoToState(); } }
      public object Menu { get { return GetValue(MenuProperty); } set { SetValue(MenuProperty, value); } }
      public new Brush BorderBrush { get { return (Brush)GetValue(BorderBrushProperty); } set { SetValue(BorderBrushProperty, value); } }
      public Brush TitleForeground { get { return (Brush)GetValue(TitleForegroundProperty); } set { SetValue(TitleForegroundProperty, value); } }
      public Brush SysButtonColor { get { return (Brush)GetValue(SysButtonColorProperty); } set { SetValue(SysButtonColorProperty, value); } }
      public Visibility SysButtonVisible { get { return (Visibility)GetValue(SysButtonVisibleProperty); } set { SetValue(SysButtonVisibleProperty, value); } }
      public Thickness SysButtonMargin { get { return (Thickness)GetValue(SysButtonMarginProperty); } set { SetValue(SysButtonMarginProperty, value); } }
      public FontSizeConverter TitleFontSize { get { return (FontSizeConverter)GetValue(TitleFontSizeProperty); } set { SetValue(TitleFontSizeProperty, value); } }

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
   }
}
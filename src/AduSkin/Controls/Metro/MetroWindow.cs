using AduSkin.Themes;
using AduSkin.Utility.Element;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public class MetroWindow : Window
    {
        public static readonly DependencyProperty IsSubWindowShowProperty = ElementBase.Property<MetroWindow, bool>("IsSubWindowShowProperty", false);
        public static readonly DependencyProperty MenuProperty = ElementBase.Property<MetroWindow, object>("MenuProperty", null);
        public static readonly new DependencyProperty BorderBrushProperty = ElementBase.Property<MetroWindow, Brush>("BorderBrushProperty");
        public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<MetroWindow, Brush>("TitleForegroundProperty");
        public static readonly DependencyProperty TitleFontSizeProperty = ElementBase.Property<MetroWindow, FontSizeConverter>("TitleFontSizeProperty");

        public bool IsSubWindowShow { get { return (bool)GetValue(IsSubWindowShowProperty); } set { SetValue(IsSubWindowShowProperty, value); GoToState(); } }
        public object Menu { get { return GetValue(MenuProperty); } set { SetValue(MenuProperty, value); } }
        public new Brush BorderBrush { get { return (Brush)GetValue(BorderBrushProperty); } set { SetValue(BorderBrushProperty, value); BorderBrushChange(value); } }
        public Brush TitleForeground { get { return (Brush)GetValue(TitleForegroundProperty); } set { SetValue(TitleForegroundProperty, value); } }
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

        static MetroWindow()
        {
            ElementBase.DefaultStyle<MetroWindow>(DefaultStyleKeyProperty);
        }
    }
}
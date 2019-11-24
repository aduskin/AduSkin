using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public partial class MetroWebBrowser : UserControl
    {
        public bool InDesignMode { get; set; } //= false;
        public Uri Source
        {
            get
            {
                return web.Url;
            }
            set
            {
                if (!DesignerProperties.GetIsInDesignMode(this) || InDesignMode)
                {
                    webp.Visibility = Visibility.Visible;
                    web.Url = value;
                }
            }
        }

        public string Document
        {
            get { return web.DocumentText; }
            set
            {
                if (!DesignerProperties.GetIsInDesignMode(this) || InDesignMode)
                {
                    webp.Visibility = Visibility.Visible;
                    web.DocumentText = value;
                }
            }
        }

        public MetroWebBrowser()
        {
            InitializeComponent();
            web.NewWindow += delegate (object sender, CancelEventArgs e)
            {
                if (web.StatusText.StartsWith("http", StringComparison.CurrentCultureIgnoreCase))
                {
                    Navigate(web.StatusText);
                }
                // 禁止跳出当前窗口
                e.Cancel = true;
            };
        }

        public void Navigate(string url)
        {
            // web.Navigate(new Uri(url));
            Source = new Uri(url);
        }
    }
}
using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace AduSkin.Controls.Metro
{
    public class XamlDisplay : ContentControl
    {
        private static readonly string AssemblyName = typeof(XamlDisplay).Assembly.GetName().Name;
        public static XName XmlName => XName.Get(nameof(XamlDisplay), $"clr-namespace:{nameof(AduSkin)};assembly={AssemblyName}");

        static XamlDisplay()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XamlDisplay), new FrameworkPropertyMetadata(typeof(XamlDisplay)));
        }

        public static readonly DependencyProperty IgnoreProperty = DependencyProperty.RegisterAttached(
            "Ignore", typeof(Scope), typeof(XamlDisplay), new PropertyMetadata(default(Scope)));

        public static void SetIgnore(DependencyObject element, Scope value)
        {
            element.SetValue(IgnoreProperty, value);
        }

        public static Scope GetIgnore(DependencyObject element)
        {
            return (Scope) element.GetValue(IgnoreProperty);
        }

        public static void Init(params Assembly[] assemblies)
        {
            if (assemblies?.Any() == true)
            {
                foreach (Assembly assembly in assemblies)
                {
                    LoadFromAssembly(assembly);
                }
            }
            LoadFromAssembly(Assembly.GetEntryAssembly());

            void LoadFromAssembly(Assembly assembly)
            {
                Type xamlDictionary = assembly?.GetType("AduSkin.XamlDictionary");
                if (xamlDictionary != null)
                {
                    //Invoke the static constructor
                    xamlDictionary.TypeInitializer.Invoke(null, null);
                }
            }
        }

        public string Key
        {
            get => _key;
            set
            {
                _key = value;
                ReloadXaml();
            }
        }

        public static readonly DependencyProperty XamlProperty = DependencyProperty.Register(
            nameof(Xaml), typeof(string), typeof(XamlDisplay), new PropertyMetadata(default(string), OnXamlChanged));

        private static void OnXamlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is XamlDisplay xamlDisplay)
            {
                xamlDisplay.ReloadXaml();
            }
        }

        public string Xaml
        {
            get => (string) GetValue(XamlProperty);
            set => SetValue(XamlProperty, value);
        }

        public static readonly DependencyProperty FormatterProperty = DependencyProperty.Register(
            nameof(Formatter), typeof(IXamlFormatter), typeof(XamlDisplay), 
            new PropertyMetadata(default(IXamlFormatter), OnXamlConverterChanged));

        private static void OnXamlConverterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is XamlDisplay xamlDisplay)
            {
                xamlDisplay.ReloadXaml();
            }
        }

        public IXamlFormatter Formatter
        {
            get => (IXamlFormatter) GetValue(FormatterProperty);
            set => SetValue(FormatterProperty, value);
        }

        private bool _isLoading;
        private string _key;

        private void ReloadXaml()
        {
            if (_isLoading) return;
            string key = Key;
            string xaml = XamlResolver.Resolve(key);
            IXamlFormatter formatter = Formatter;
            if (formatter != null)
            {
                xaml = formatter.FormatXaml(xaml);
            }
            _isLoading = true;
            SetCurrentValue(XamlProperty, xaml);
            _isLoading = false;
        }
    }
}

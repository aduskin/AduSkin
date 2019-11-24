using AduSkin.Utility.Element;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public class MetroExpander : ContentControl
    {
        public static readonly DependencyProperty IsExpandedProperty = ElementBase.Property<MetroExpander, bool>("IsExpandedProperty");
        public static readonly DependencyProperty CanHideProperty = ElementBase.Property<MetroExpander, bool>("CanHideProperty");
        public static readonly DependencyProperty HeaderProperty = ElementBase.Property<MetroExpander, string>("HeaderProperty");
        public static readonly DependencyProperty HintProperty = ElementBase.Property<MetroExpander, string>("HintProperty");
        public static readonly DependencyProperty HintBackgroundProperty = ElementBase.Property<MetroExpander, Brush>("HintBackgroundProperty");
        public static readonly DependencyProperty HintForegroundProperty = ElementBase.Property<MetroExpander, Brush>("HintForegroundProperty");
        public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroExpander, ImageSource>("IconProperty", null);

        public static RoutedUICommand ButtonClickCommand = ElementBase.Command<MetroExpander>("ButtonClickCommand");

        public bool IsExpanded { get { return (bool)GetValue(IsExpandedProperty); } set { SetValue(IsExpandedProperty, value); ElementBase.GoToState(this, IsExpanded ? "Expand" : "Normal"); } }
        public bool CanHide { get { return (bool)GetValue(CanHideProperty); } set { SetValue(CanHideProperty, value); } }
        public string Header { get { return (string)GetValue(HeaderProperty); } set { SetValue(HeaderProperty, value); } }
        public string Hint { get { return (string)GetValue(HintProperty); } set { SetValue(HintProperty, value); } }
        public Brush HintBackground { get { return (Brush)GetValue(HintBackgroundProperty); } set { SetValue(HintBackgroundProperty, value); } }
        public Brush HintForeground { get { return (Brush)GetValue(HintForegroundProperty); } set { SetValue(HintForegroundProperty, value); } }
        public ImageSource Icon { get { return (ImageSource)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }

        public event EventHandler Click;

        public MetroExpander()
        {
            Utility.Refresh(this);

            Loaded += delegate
            {
                if (Content == null)
                {
                    IsExpanded = false;
                }
                else if (!CanHide)
                {
                    IsExpanded = true;
                }
                ElementBase.GoToState(this, IsExpanded ? "StartExpand" : "StartNormal");
            };

            CommandBindings.Add(new CommandBinding(ButtonClickCommand, delegate
            {
                if (CanHide && Content != null)
                {
                    IsExpanded = !IsExpanded;
                }
                if (Click != null) { Click(this, null); }
            }));
        }

        public void Clear()
        {
            Content = new StackPanel();
        }

        public UIElementCollection Children
        {
            get
            {
                if ((Content is StackPanel))
                {
                    return (Content as StackPanel).Children;
                }
                else if ((Content is Grid))
                {
                    return (Content as Grid).Children;
                }
                return null;
            }
        }

        public void Add(FrameworkElement element)
        {
            if (!(Content is StackPanel))
            {
                Content = new StackPanel();
            }
            (Content as StackPanel).Children.Add(element);
        }

        static MetroExpander()
        {
            ElementBase.DefaultStyle<MetroExpander>(DefaultStyleKeyProperty);
        }
    }
}
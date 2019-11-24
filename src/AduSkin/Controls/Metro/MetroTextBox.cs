using AduSkin.Utility.Element;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public class MetroTextBox : TextBox
    {
        public static readonly DependencyProperty TitleProperty = ElementBase.Property<MetroTextBox, string>("TitleProperty", "");
        public static readonly DependencyProperty TitleMinWidthProperty = ElementBase.Property<MetroTextBox, double>("TitleMinWidthProperty");
        public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<MetroTextBox, Brush>("TitleForegroundProperty");
        public static readonly DependencyProperty MouseMoveBackgroundProperty = ElementBase.Property<MetroTextBox, Brush>("MouseMoveBackgroundProperty");
        public static readonly DependencyProperty InputHintProperty = ElementBase.Property<MetroTextBox, string>("InputHintProperty", "");
        public static readonly DependencyProperty PopupHintProperty = ElementBase.Property<MetroTextBox, string>("PopupHintProperty", "");
        public static readonly DependencyProperty ButtonTitleProperty = ElementBase.Property<MetroTextBox, string>("ButtonTitleProperty", "");
        public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroTextBox, ImageSource>("IconProperty", null);
        public static readonly DependencyProperty StateProperty = ElementBase.Property<MetroTextBox, string>("StateProperty", "");
        public static readonly DependencyProperty MultipleLineProperty = ElementBase.Property<MetroTextBox, bool>("MultipleLineProperty", false);
        public static readonly DependencyProperty IsPassWordBoxProperty = ElementBase.Property<MetroTextBox, bool>("IsPassWordBoxProperty", false);
        public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroTextBox, CornerRadius>("CornerRadiusProperty");

        public static RoutedUICommand ButtonClickCommand = ElementBase.Command<MetroTextBox>("ButtonClickCommand");

        public string Title { get { return (string)GetValue(TitleProperty); } set { SetValue(TitleProperty, value); } }
        public double TitleMinWidth { get { return (double)GetValue(TitleMinWidthProperty); } set { SetValue(TitleMinWidthProperty, value); } }
        public Brush TitleForeground { get { return (Brush)GetValue(TitleForegroundProperty); } set { SetValue(TitleForegroundProperty, value); } }
        public Brush MouseMoveBackground { get { return (Brush)GetValue(MouseMoveBackgroundProperty); } set { SetValue(MouseMoveBackgroundProperty, value); } }
        public string InputHint { get { return (string)GetValue(InputHintProperty); } set { SetValue(InputHintProperty, value); } }
        public string PopupHint { get { return (string)GetValue(PopupHintProperty); } set { SetValue(PopupHintProperty, value); } }
        public string ButtonTitle { get { return (string)GetValue(ButtonTitleProperty); } set { SetValue(ButtonTitleProperty, value); } }
        public ImageSource Icon { get { return (ImageSource)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }
        public string State { get { return (string)GetValue(StateProperty); } set { SetValue(StateProperty, value); } }
        public bool MultipleLine { get { return (bool)GetValue(MultipleLineProperty); } set { SetValue(MultipleLineProperty, value); } }
        public bool IsPassWordBox { get { return (bool)GetValue(IsPassWordBoxProperty); } set { SetValue(IsPassWordBoxProperty, value); } }
        public CornerRadius CornerRadius { get { return (CornerRadius)GetValue(CornerRadiusProperty); } set { SetValue(CornerRadiusProperty, value); } }



        public Func<string, bool> ErrorCheckAction { get; set; }
        public event EventHandler ButtonClick;

        public MetroTextBox()
        {
            ContextMenu = null;
            Loaded += delegate { ErrorCheck(); };
            TextChanged += delegate { ErrorCheck(); };
            CommandBindings.Add(new CommandBinding(ButtonClickCommand, delegate { if (ButtonClick != null) { ButtonClick(this, null); } }));
            Utility.Refresh(this);
        }

        void ErrorCheck()
        {
            // if (PopupHint == null || PopupHint == "") { PopupHint = InputHint; }
            if (ErrorCheckAction != null) { State = ErrorCheckAction(Text) ? "true" : "false"; }
        }

        static MetroTextBox()
        {
            ElementBase.DefaultStyle<MetroTextBox>(DefaultStyleKeyProperty);
        }
    }
}
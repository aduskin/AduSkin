using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public class AduTabItem : TabItem
    {
        public static readonly DependencyProperty RemarkProperty = ElementBase.Property<AduTabItem, ImageSource>("RemarkProperty", null);

        public string Remark { get { return (string)GetValue(RemarkProperty); } set { SetValue(RemarkProperty, value); } }

        static AduTabItem()
        {
            ElementBase.DefaultStyle<AduTabItem>(DefaultStyleKeyProperty);
        }
    }
}
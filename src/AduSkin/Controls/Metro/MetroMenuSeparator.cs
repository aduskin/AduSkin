using AduSkin.Utility.Element;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class MetroMenuSeparator : Separator
    {
        static MetroMenuSeparator()
        {
            ElementBase.DefaultStyle<MetroMenuSeparator>(DefaultStyleKeyProperty);
        }
    }
}
using AduSkin.Utility.Element;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class MetroTextButton : Button
    {
        static MetroTextButton()
        {
            ElementBase.DefaultStyle<MetroTextButton>(DefaultStyleKeyProperty);
        }
    }
}
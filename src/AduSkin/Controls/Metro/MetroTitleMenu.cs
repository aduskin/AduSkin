using AduSkin.Utility.Element;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class MetroTitleMenu : Menu
    {
        public MetroTitleMenu()
        {
            
        }

        static MetroTitleMenu()
        {
            ElementBase.DefaultStyle<MetroTitleMenu>(DefaultStyleKeyProperty);
        }
    }
}
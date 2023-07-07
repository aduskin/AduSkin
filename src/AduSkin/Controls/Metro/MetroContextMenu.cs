using AduSkin.Utility.Element;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class MetroContextMenu : ContextMenu
    {
        public MetroContextMenu()
        {
            
        }

        static MetroContextMenu()
        {
            ElementBase.DefaultStyle<MetroContextMenu>(DefaultStyleKeyProperty);
        }
    }
}
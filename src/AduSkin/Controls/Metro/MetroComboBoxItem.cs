using AduSkin.Utility.Element;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class MetroComboBoxItem : ComboBoxItem
    {
        public MetroComboBoxItem()
        {
            
        }

        static MetroComboBoxItem()
        {
            ElementBase.DefaultStyle<MetroComboBoxItem>(DefaultStyleKeyProperty);
        }
    }
}
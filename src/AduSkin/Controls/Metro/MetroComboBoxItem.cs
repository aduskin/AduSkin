using AduSkin.Utility.Element;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class MetroComboBoxItem : ComboBoxItem
    {
        public MetroComboBoxItem()
        {
            Utility.Refresh(this);
        }

        static MetroComboBoxItem()
        {
            ElementBase.DefaultStyle<MetroComboBoxItem>(DefaultStyleKeyProperty);
        }
    }
}
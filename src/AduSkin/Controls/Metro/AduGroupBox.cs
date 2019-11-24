using AduSkin.Utility.Element;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class AduGroupBox : GroupBox
    {
        static AduGroupBox()
        {
            ElementBase.DefaultStyle<AduGroupBox>(DefaultStyleKeyProperty);
        }
    }
}
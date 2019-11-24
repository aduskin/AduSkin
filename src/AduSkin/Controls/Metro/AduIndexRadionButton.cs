using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class AduIndexRadionButton : RadioButton
    {
        static AduIndexRadionButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduIndexRadionButton), new FrameworkPropertyMetadata(typeof(AduIndexRadionButton)));
        }
    }
}

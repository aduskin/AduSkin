using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class AduFlatRadionButton: RadioButton
    {
        static AduFlatRadionButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduFlatRadionButton), new FrameworkPropertyMetadata(typeof(AduFlatRadionButton)));
        }
    }
}

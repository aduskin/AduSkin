using AduSkin.Utility.Element;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class AduSlider : Slider
    {
        static AduSlider()
        {
            ElementBase.DefaultStyle<AduSlider>(DefaultStyleKeyProperty);
        }
    }
}
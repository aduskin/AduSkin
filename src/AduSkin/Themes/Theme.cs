using System.Windows;
using System.Windows.Media;

namespace AduSkin.Themes
{
    public class Theme
    {
        public static void Switch(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                if (childVisual != null)
                {
                    Controls.Utility.Refresh(childVisual as FrameworkElement);
                    Switch(childVisual);
                }
            }
        }
    }
}
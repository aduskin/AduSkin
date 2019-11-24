using System;
using System.Windows.Media;

namespace AduSkin.Utility.Element
{
    public class VisualObj
    {
        public static void ActionOnAllElement(Visual visual, Action<Visual> action)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(visual, i);
                if (childVisual != null)
                {
                    action(childVisual);
                    ActionOnAllElement(childVisual, action);
                }
            }
        }
    }
}
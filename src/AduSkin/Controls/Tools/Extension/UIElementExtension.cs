using AduSkin.Controls.Metro;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace AduSkin.Controls.Tools.Extension
{
    // ReSharper disable once InconsistentNaming
    public static class UIElementExtension
    {
        /// <summary>
        ///     显示元素
        /// </summary>
        /// <param name="element"></param>
        public static void Show(this UIElement element)
        {
            element.Visibility = Visibility.Visible;
        }

        /// <summary>
        ///     显示元素
        /// </summary>
        /// <param name="element"></param>
        /// <param name="show"></param>
        public static void Show(this UIElement element, bool show)
        {
            element.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        ///     不现实元素，但保留空间
        /// </summary>
        /// <param name="element"></param>
        public static void Hide(this UIElement element)
        {
            element.Visibility = Visibility.Hidden;
        }

        /// <summary>
        ///     不显示元素，且不保留空间
        /// </summary>
        /// <param name="element"></param>
        public static void Collapse(this UIElement element)
        {
            element.Visibility = Visibility.Collapsed;
        }

      public static double RoundLayoutValue(double value, double dpiScale)
      {
         double num;
         if (!DoubleUtil.AreClose(dpiScale, 1.0))
         {
            num = Math.Round(value * dpiScale) / dpiScale;
            if (DoubleUtil.IsNaN(num) || double.IsInfinity(num) || DoubleUtil.AreClose(num, 1.7976931348623157E+308))
            {
               num = value;
            }
         }
         else
         {
            num = Math.Round(value);
         }
         return num;
      }

      public static T GetAdorner<T>(DependencyObject d) where T : class
      {
         var element = d as FrameworkElement;

         if (element != null)
         {
            var adornerLayer = AdornerLayer.GetAdornerLayer(element);
            if (adornerLayer != null)
            {
               //能够获取装饰层，说明已经load过了，直接生成装饰件
               var adorners = adornerLayer.GetAdorners(element);
               if (adorners != null && adorners.Count() != 0)
               {
                  var adorner = adorners.FirstOrDefault() as T;

                  return adorner;
               }
            }
         }

         return null;
      }
   }
}
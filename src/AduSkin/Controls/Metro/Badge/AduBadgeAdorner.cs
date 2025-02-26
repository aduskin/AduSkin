using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   /// <summary>
   /// 角标类型
   /// </summary>
   public enum BadgeType
   {
      /// <summary>
      /// 显示成一个圆点
      /// </summary>
      Dot,
      /// <summary>
      /// 显示成正常有数字的圆形
      /// </summary>
      Normal,
   }

   /// <summary>
   /// 角标装饰器，用于给各类控件添加右上角角标显示
   /// </summary>
   public class AduBadgeAdorner : Adorner
   {
      private AduBadge badge;
      private VisualCollection _visuals;

      public AduBadgeAdorner(UIElement adornedElement) : base(adornedElement)
      {
         _visuals = new VisualCollection(this);
         TranslateTransform tt = new TranslateTransform();
         tt.X = 13;
         tt.Y = -10;
         badge = new AduBadge()
         {
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Top,
            RenderTransform = tt,
         };

         //这行代码是使用Path=(ZUI:AduBadgeAdorner.Number)的关键代码
         badge.DataContext = adornedElement;

         _visuals.Add(badge);
      }

      protected override int VisualChildrenCount
      {
         get
         {
            return _visuals.Count;
         }
      }

      protected override Visual GetVisualChild(int index)
      {
         return _visuals[index];
      }

      protected override Size MeasureOverride(Size constraint)
      {
         return base.MeasureOverride(constraint);
      }

      protected override Size ArrangeOverride(Size finalSize)
      {
         badge.Arrange(new Rect(finalSize));

         return base.ArrangeOverride(finalSize);
      }

      #region 附加属性定义
      /// <summary>
      /// 是否添加角标
      /// </summary>
      public static readonly DependencyProperty HasAdornerProperty =
          DependencyProperty.RegisterAttached("HasAdorner", typeof(bool),
              typeof(AduBadgeAdorner), new PropertyMetadata(false, HasAdornerChangedCallBack));

      /// <summary>
      /// 是否显示角标(Badge已经存在，只不过显示不显示的问题)
      /// </summary>
      public static readonly DependencyProperty IsShowAdornerProperty =
          DependencyProperty.RegisterAttached("IsShowAdorner", typeof(bool),
              typeof(AduBadgeAdorner), new PropertyMetadata(false, IsShowChangedCallBack));

      /// <summary>
      /// 角标显示的数字
      /// </summary>
      public static readonly DependencyProperty NumberProperty =
          DependencyProperty.RegisterAttached("Number", typeof(int),
              typeof(AduBadgeAdorner), new PropertyMetadata(0, NumberChangedCallBack, CoerceNumberCallback));

      /// <summary>
      /// 角标背景色
      /// </summary>
      public static readonly DependencyProperty BackgroundProperty =
          DependencyProperty.RegisterAttached("Background", typeof(Brush),
              typeof(AduBadgeAdorner));

      public static readonly DependencyProperty BadgeTypeProperty =
          DependencyProperty.RegisterAttached("BadgeType", typeof(BadgeType),
              typeof(AduBadgeAdorner), new PropertyMetadata(BadgeType.Normal, BadgeTypeChangeCallback));

      #endregion

      #region 附加属性set get

      #region HasAdorner
      public static bool GetHasAdorner(DependencyObject obj)
      {
         return (bool)obj.GetValue(HasAdornerProperty);
      }

      public static void SetHasAdorner(DependencyObject obj, bool value)
      {
         obj.SetValue(HasAdornerProperty, value);
      }
      #endregion

      #region IsShowAdorner
      public static bool GetIsShowAdorner(DependencyObject obj)
      {
         return (bool)obj.GetValue(IsShowAdornerProperty);
      }

      public static void SetIsShowAdorner(DependencyObject obj, bool value)
      {
         obj.SetValue(IsShowAdornerProperty, value);
      }
      #endregion

      #region Number
      public static int GetNumber(DependencyObject obj)
      {
         return (int)obj.GetValue(NumberProperty);
      }

      public static void SetNumber(DependencyObject obj, int value)
      {
         obj.SetValue(NumberProperty, value);
      }
      #endregion

      #region Background
      public static Brush GetBackground(DependencyObject obj)
      {
         return (Brush)obj.GetValue(AduBadge.BackgroundProperty);
      }

      public static void SetBackground(DependencyObject obj, Brush value)
      {
         obj.SetValue(AduBadge.BackgroundProperty, value);
      }
      #endregion

      #region BadgeType
      public static BadgeType GetBadgeType(DependencyObject obj)
      {
         return (BadgeType)obj.GetValue(BadgeTypeProperty);
      }

      public static void SetBadgeType(DependencyObject obj, BadgeType value)
      {
         obj.SetValue(BadgeTypeProperty, value);
      }
      #endregion

      #endregion

      #region 附加属性回调方法
      private static void HasAdornerChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         var element = d as FrameworkElement;
         if ((bool)e.NewValue)
         {
            if (element != null)
            {
               var adornerLayer = AdornerLayer.GetAdornerLayer(element);

               if (adornerLayer != null)
               {
                  adornerLayer.Add(new AduBadgeAdorner(element as UIElement));
               }
               else
               {
                  //layer为null，说明还未load过（整个可视化树中没有装饰层的情况不考虑）
                  //在控件的loaded事件内生成装饰件
                  element.Loaded += (s1, e1) =>
                  {
                     var adorner = new AduBadgeAdorner(element);
                     AdornerLayer.GetAdornerLayer(element).Add(adorner);
                  };
               }
            }
         }
         else
         {
            //装饰件不可用，移除装饰件
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(element);
            if (layer != null)
            {
               Adorner[] AllAdorners = layer.GetAdorners(element);
               if (AllAdorners != null)
               {
                  IEnumerable<Adorner> desAdorners = AllAdorners.Where(p => p is AduBadgeAdorner);
                  if (desAdorners != null && desAdorners.Count() > 0)
                  {
                     desAdorners.ToList().ForEach(p => layer.Remove(p));
                  }
               }
            }
         }
      }

      private static void IsShowChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduBadgeAdorner adorner = AduBadgeAdorner.GetAdorner(d);
         if (adorner == null)
         {
            return;
         }

         if ((bool)e.NewValue)
         {
            adorner.ShowAdorner();
         }
         else
         {
            adorner.HideAdorner();
         }
      }

      private static void NumberChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {

      }

      private static object CoerceNumberCallback(DependencyObject d, object baseValue)
      {
         int promptCount = (int)baseValue;
         promptCount = Math.Max(0, promptCount);

         return promptCount;
      }

      private static void BadgeTypeChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduBadgeAdorner adorner = AduBadgeAdorner.GetAdorner(d);

         if (adorner == null)
         {
            return;
         }

         if ((BadgeType)e.NewValue == BadgeType.Dot)
         {
            adorner.SowDot();
         }
         else
         {
            adorner.ShowNormal();
         }
      }

      #endregion

      #region Private 方法
      private void ShowAdorner()
      {
         badge.Visibility = Visibility.Visible;
      }

      private void HideAdorner()
      {
         badge.Visibility = Visibility.Collapsed;
      }

      private void ShowNormal()
      {
         TranslateTransform tt = new TranslateTransform();
         tt.X = 10;
         tt.Y = -10;
         this.badge.RenderTransform = tt;
         this.badge.IsDot = false;
      }

      private void SowDot()
      {
         TranslateTransform tt = new TranslateTransform();
         tt.X = 4;
         tt.Y = -4;
         this.badge.RenderTransform = tt;
         this.badge.IsDot = true;
      }

      private static AduBadgeAdorner GetAdorner(DependencyObject d)
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
                  return adorners.FirstOrDefault() as AduBadgeAdorner;
               }
            }
         }
         return null;
      }
      #endregion
   }
}

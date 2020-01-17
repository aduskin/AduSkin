using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public class AduTabItem : TabItem
    {
        public static readonly DependencyProperty RemarkProperty = ElementBase.Property<AduTabItem, ImageSource>("RemarkProperty", null);

        public string Remark { get { return (string)GetValue(RemarkProperty); } set { SetValue(RemarkProperty, value); } }

        public AduTabItem()
        {
           Utility.Refresh(this);
        }

      static AduTabItem()
        {
            ElementBase.DefaultStyle<AduTabItem>(DefaultStyleKeyProperty);
        }
      #region Path属性
      public static readonly DependencyProperty PathWidthProperty = DependencyProperty.Register("PathWidth"
          , typeof(double), typeof(AduTabItem), new FrameworkPropertyMetadata(0d));
      /// <summary>
      /// Path的宽度
      /// </summary>
      public double PathWidth
      {
         get { return (double)GetValue(PathWidthProperty); }
         set { SetValue(PathWidthProperty, value); }
      }

      public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register("PathData"
          , typeof(Geometry), typeof(AduTabItem));
      /// <summary>
      /// Path的Data
      /// </summary>
      public Geometry PathData
      {
         get { return (Geometry)GetValue(PathDataProperty); }
         set { SetValue(PathDataProperty, value); }
      }

      public static readonly DependencyProperty IconTextMarginProperty =
          DependencyProperty.Register("IconTextMargin", typeof(double), typeof(AduTabItem), new PropertyMetadata(0.0));
      /// <summary>
      /// 图标文字间隔
      /// </summary>
      public double IconTextMargin
      {
         get { return (double)GetValue(IconTextMarginProperty); }
         set { SetValue(IconTextMarginProperty, value); }
      }
      #endregion
   }
}
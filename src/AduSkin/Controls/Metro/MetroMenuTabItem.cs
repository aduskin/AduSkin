using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public class MetroMenuTabItem : TabItem
    {
        //public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroMenuTabItem, IconSource>("IconProperty", null);
        //public static readonly DependencyProperty IconMoveProperty = ElementBase.Property<MetroMenuTabItem, IconSource>("IconMoveProperty", null);
        public static readonly DependencyProperty TextHorizontalAlignmentProperty = ElementBase.Property<MetroMenuTabItem, HorizontalAlignment>("TextHorizontalAlignmentProperty", HorizontalAlignment.Right);

        //public IconSource Icon { get { return (IconSource)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }
        //public IconSource IconMove { get { return (IconSource)GetValue(IconMoveProperty); } set { SetValue(IconMoveProperty, value); } }
        public HorizontalAlignment TextHorizontalAlignment { get { return (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty); } set { SetValue(TextHorizontalAlignmentProperty, value); } }

        static MetroMenuTabItem()
        {
            ElementBase.DefaultStyle<MetroMenuTabItem>(DefaultStyleKeyProperty);
        }

        #region AduSkin
        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(MetroMenuTabItem));

        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(double), typeof(MetroMenuTabItem), new PropertyMetadata(20.0));

        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.Register("IconHeight", typeof(double), typeof(MetroMenuTabItem), new PropertyMetadata(20.0));

      /// <summary>
      /// 鼠标悬浮时按钮的背景色
      /// </summary>
      public Brush MouseOverColor
      {
         get { return (Brush)GetValue(MouseOverColorProperty); }
         set { SetValue(MouseOverColorProperty, value); }
      }

      public static readonly DependencyProperty MouseOverColorProperty = DependencyProperty.Register("MouseOverColor"
            , typeof(Brush), typeof(MetroMenuTabItem), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 255, 255))));
      
      
      #endregion
   }
}
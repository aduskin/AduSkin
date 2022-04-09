using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduFormLable : Label
   {
      //标题
      public static readonly DependencyProperty TitleProperty = ElementBase.Property<AduFormLable, string>("TitleProperty", "");
      //标题宽度
      public static readonly DependencyProperty TitleWidthProperty = ElementBase.Property<AduFormLable, double>("TitleWidthProperty");
      //标题靠左右
      public static readonly DependencyProperty TitleHorizontalAlignmentProperty = ElementBase.Property<AduFormLable, HorizontalAlignment>("TitleHorizontalAlignmentProperty", HorizontalAlignment.Center);
      //标题靠上下
      public static readonly DependencyProperty TitleVerticalAlignmentProperty = ElementBase.Property<AduFormLable, VerticalAlignment>("TitleVerticalAlignmentProperty", VerticalAlignment.Center);
      //标题颜色
      public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<AduFormLable, Brush>("TitleForegroundProperty");
      //错误信息
      public static readonly DependencyProperty ErrorMessageProperty = ElementBase.Property<AduFormLable, string>("ErrorMessageProperty", "");
      //错误颜色
      public static readonly DependencyProperty ErrorForegroundProperty = ElementBase.Property<AduFormLable, Brush>("ErrorForegroundProperty");
      //显示错误信息
      public static readonly DependencyProperty ErrorVisibilityProperty = ElementBase.Property<AduFormLable, Visibility>("ErrorVisibilityProperty", Visibility.Collapsed);

      public string Title { get { return (string)GetValue(TitleProperty); } set { SetValue(TitleProperty, value); } }
      public double TitleWidth { get { return (double)GetValue(TitleWidthProperty); } set { SetValue(TitleWidthProperty, value); } }
      public HorizontalAlignment TitleHorizontalAlignment { get { return (HorizontalAlignment)GetValue(TitleHorizontalAlignmentProperty); } set { SetValue(TitleHorizontalAlignmentProperty, value); } }
      public HorizontalAlignment TitleVerticalAlignment { get { return (HorizontalAlignment)GetValue(TitleVerticalAlignmentProperty); } set { SetValue(TitleVerticalAlignmentProperty, value); } }
      public Brush TitleForeground { get { return (Brush)GetValue(TitleForegroundProperty); } set { SetValue(TitleForegroundProperty, value); } }
      public string ErrorMessage { get { return (string)GetValue(ErrorMessageProperty); } set { SetValue(ErrorMessageProperty, value); } }
      public Brush ErrorForeground { get { return (Brush)GetValue(ErrorForegroundProperty); } set { SetValue(ErrorForegroundProperty, value); } }
      public Visibility ErrorVisibility { get { return (Visibility)GetValue(ErrorVisibilityProperty); } set { SetValue(ErrorVisibilityProperty, value); } }

      public AduFormLable()
      {
         Utility.Refresh(this);
      }

      static AduFormLable()
      {
         ElementBase.DefaultStyle<AduFormLable>(DefaultStyleKeyProperty);
      }
   }
}

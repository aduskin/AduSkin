using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduFormLable : Label
   {
      /// <summary>
      /// 标题
      /// </summary>
      public static readonly DependencyProperty TitleProperty = ElementBase.Property<AduFormLable, string>("TitleProperty", "");
      /// <summary>
      /// 标题宽度
      /// </summary>
      public static readonly DependencyProperty TitleWidthProperty = ElementBase.Property<AduFormLable, double>("TitleWidthProperty");
      /// <summary>
      /// 标题最小宽度
      /// </summary>
      public static readonly DependencyProperty TitleMinWidthProperty = ElementBase.Property<AduFormLable, double>("TitleMinWidthProperty");
      /// <summary>
      /// 标题靠左右
      /// </summary>
      public static readonly DependencyProperty TitleHorizontalAlignmentProperty = ElementBase.Property<AduFormLable, HorizontalAlignment>("TitleHorizontalAlignmentProperty", HorizontalAlignment.Center);
      /// <summary>
      /// 标题内边距
      /// </summary>
      public static readonly DependencyProperty TitlePaddingProperty = ElementBase.Property<AduFormLable, Thickness>("TitlePaddingProperty");
      /// <summary>
      /// 标题靠上下
      /// </summary>
      public static readonly DependencyProperty TitleVerticalAlignmentProperty = ElementBase.Property<AduFormLable, VerticalAlignment>("TitleVerticalAlignmentProperty", VerticalAlignment.Center);
      /// <summary>
      /// 标题颜色
      /// </summary>
      public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<AduFormLable, Brush>("TitleForegroundProperty");
      /// <summary>
      /// 错误信息
      /// </summary>
      public static readonly DependencyProperty ErrorMessageProperty = ElementBase.Property<AduFormLable, string>("ErrorMessageProperty", "");
      /// <summary>
      /// 错误颜色
      /// </summary>
      public static readonly DependencyProperty ErrorForegroundProperty = ElementBase.Property<AduFormLable, Brush>("ErrorForegroundProperty");
      /// <summary>
      /// 显示错误信息
      /// </summary>
      public static readonly DependencyProperty ErrorVisibilityProperty = ElementBase.Property<AduFormLable, Visibility>("ErrorVisibilityProperty", Visibility.Collapsed);

      public string Title { get { return (string)GetValue(TitleProperty); } set { SetValue(TitleProperty, value); } }
      public double TitleMinWidth { get { return (double)GetValue(TitleMinWidthProperty); } set { SetValue(TitleMinWidthProperty, value); } }
      public double TitleWidth { get { return (double)GetValue(TitleWidthProperty); } set { SetValue(TitleWidthProperty, value); } }
      public HorizontalAlignment TitleHorizontalAlignment { get { return (HorizontalAlignment)GetValue(TitleHorizontalAlignmentProperty); } set { SetValue(TitleHorizontalAlignmentProperty, value); } }
      public VerticalAlignment TitleVerticalAlignment { get { return (VerticalAlignment)GetValue(TitleVerticalAlignmentProperty); } set { SetValue(TitleVerticalAlignmentProperty, value); } }
      public Thickness TitlePadding { get { return (Thickness)GetValue(TitlePaddingProperty); } set { SetValue(TitlePaddingProperty, value); } }
      public Brush TitleForeground { get { return (Brush)GetValue(TitleForegroundProperty); } set { SetValue(TitleForegroundProperty, value); } }
      public string ErrorMessage { get { return (string)GetValue(ErrorMessageProperty); } set { SetValue(ErrorMessageProperty, value); } }
      public Brush ErrorForeground { get { return (Brush)GetValue(ErrorForegroundProperty); } set { SetValue(ErrorForegroundProperty, value); } }
      public Visibility ErrorVisibility { get { return (Visibility)GetValue(ErrorVisibilityProperty); } set { SetValue(ErrorVisibilityProperty, value); } }

      public AduFormLable()
      {
         
      }

      static AduFormLable()
      {
         ElementBase.DefaultStyle<AduFormLable>(DefaultStyleKeyProperty);
      }
   }
}

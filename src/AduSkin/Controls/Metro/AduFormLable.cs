using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduFormLable : Label
   {
      public AduFormLable()
      {

      }
      static AduFormLable()
      {
         ElementBase.DefaultStyle<AduFormLable>(DefaultStyleKeyProperty);
      }

      #region 标题
      /// <summary>
      /// 标题
      /// </summary>
      public static readonly DependencyProperty TitleProperty = ElementBase.Property<AduFormLable, string>("TitleProperty", "");
      public string Title
      {
         get { return (string)GetValue(TitleProperty); }
         set { SetValue(TitleProperty, value); }
      }
      /// <summary>
      /// 标题宽度
      /// </summary>
      public static readonly DependencyProperty TitleWidthProperty = ElementBase.Property<AduFormLable, double>("TitleWidthProperty");
      public double TitleWidth
      {
         get { return (double)GetValue(TitleWidthProperty); }
         set { SetValue(TitleWidthProperty, value); }
      }
      /// <summary>
      /// 标题最小宽度
      /// </summary>
      public static readonly DependencyProperty TitleMinWidthProperty = ElementBase.Property<AduFormLable, double>("TitleMinWidthProperty");
      public double TitleMinWidth
      {
         get { return (double)GetValue(TitleMinWidthProperty); }
         set { SetValue(TitleMinWidthProperty, value); }
      }
      /// <summary>
      /// 标题靠左右
      /// </summary>
      public static readonly DependencyProperty TitleHorizontalAlignmentProperty = ElementBase.Property<AduFormLable, TextAlignment>("TitleHorizontalAlignmentProperty", TextAlignment.Center);
      public TextAlignment TitleHorizontalAlignment
      {
         get { return (TextAlignment)GetValue(TitleHorizontalAlignmentProperty); }
         set { SetValue(TitleHorizontalAlignmentProperty, value); }
      }
      /// <summary>
      /// 标题内边距
      /// </summary>
      public static readonly DependencyProperty TitlePaddingProperty = ElementBase.Property<AduFormLable, Thickness>("TitlePaddingProperty");
      public Thickness TitlePadding
      {
         get { return (Thickness)GetValue(TitlePaddingProperty); }
         set { SetValue(TitlePaddingProperty, value); }
      }
      /// <summary>
      /// 标题靠上下
      /// </summary>
      public static readonly DependencyProperty TitleVerticalAlignmentProperty = ElementBase.Property<AduFormLable, VerticalAlignment>("TitleVerticalAlignmentProperty", VerticalAlignment.Center);
      public VerticalAlignment TitleVerticalAlignment
      {
         get { return (VerticalAlignment)GetValue(TitleVerticalAlignmentProperty); }
         set { SetValue(TitleVerticalAlignmentProperty, value); }
      }
      /// <summary>
      /// 标题颜色
      /// </summary>
      public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<AduFormLable, Brush>("TitleForegroundProperty");

      public Brush TitleForeground
      {
         get { return (Brush)GetValue(TitleForegroundProperty); }
         set { SetValue(TitleForegroundProperty, value); }
      }
      #endregion

      #region 结尾提示语
      /// <summary>
      /// 错误信息
      /// </summary>
      public static readonly DependencyProperty PromptProperty = ElementBase.Property<AduFormLable, string>("PromptProperty", "");
      public string Prompt
      {
         get { return (string)GetValue(PromptProperty); }
         set { SetValue(PromptProperty, value); }
      }
      /// <summary>
      /// 错误颜色
      /// </summary>
      public static readonly DependencyProperty PromptForegroundProperty = ElementBase.Property<AduFormLable, Brush>("PromptForegroundProperty", new SolidColorBrush(Colors.Black));
      public Brush PromptForeground
      {
         get { return (Brush)GetValue(PromptForegroundProperty); }
         set { SetValue(PromptForegroundProperty, value); }
      }
      /// <summary>
      /// 显示错误信息
      /// </summary>
      public static readonly DependencyProperty PromptVisibilityProperty = ElementBase.Property<AduFormLable, Visibility>("PromptVisibilityProperty", Visibility.Collapsed);
      public Visibility PromptVisibility
      {
         get { return (Visibility)GetValue(PromptVisibilityProperty); }
         set { SetValue(PromptVisibilityProperty, value); }
      }
      #endregion
   }
}

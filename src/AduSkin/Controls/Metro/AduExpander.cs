using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduExpander : Expander
   {
      static AduExpander()
      {
         ElementBase.DefaultStyle<AduExpander>(DefaultStyleKeyProperty);
      }
      #region Private属性
      private FrameworkElement PART_Root;
      #endregion

      #region Override方法
      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();
         this.PART_Root = this.GetTemplateChild("PART_Root") as FrameworkElement;
         if (this.PART_Root != null)
         {
            VisualStateManager.GoToElementState(this.PART_Root, this.IsExpanded ? "Storyboard_Expanded" : "Storyboard_Collapsed", true);
         }
      }
      protected override void OnCollapsed()
      {
         base.OnCollapsed();
         if (this.PART_Root != null)
         {
            VisualStateManager.GoToElementState(this.PART_Root, "Storyboard_Collapsed", true);
         }
      }
      protected override void OnExpanded()
      {
         base.OnExpanded();
         if (this.PART_Root != null)
         {
            VisualStateManager.GoToElementState(this.PART_Root, "Storyboard_Expanded" , true);
         }
      }
      #endregion

      #region AduSkin
      public Geometry Icon
      {
         get { return (Geometry)GetValue(IconProperty); }
         set { SetValue(IconProperty, value); }
      }

      public static readonly DependencyProperty IconProperty =
          DependencyProperty.Register("Icon", typeof(Geometry), typeof(AduExpander));

      public double IconWidth
      {
         get { return (double)GetValue(IconWidthProperty); }
         set { SetValue(IconWidthProperty, value); }
      }

      public static readonly DependencyProperty IconWidthProperty =
          DependencyProperty.Register("IconWidth", typeof(double), typeof(AduExpander), new PropertyMetadata(20.0));

      public double IconHeight
      {
         get { return (double)GetValue(IconHeightProperty); }
         set { SetValue(IconHeightProperty, value); }
      }

      public static readonly DependencyProperty IconHeightProperty =
          DependencyProperty.Register("IconHeight", typeof(double), typeof(AduExpander), new PropertyMetadata(20.0));

      #endregion
   }
}
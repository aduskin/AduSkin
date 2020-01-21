using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduRadioButton : RadioButton
   {
      public static readonly DependencyProperty TextHorizontalAlignmentProperty = ElementBase.Property<AduRadioButton, HorizontalAlignment>("TextHorizontalAlignmentProperty", HorizontalAlignment.Right);

      public HorizontalAlignment TextHorizontalAlignment { get { return (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty); } set { SetValue(TextHorizontalAlignmentProperty, value); } }

      public AduRadioButton()
      {
         Utility.Refresh(this);
      }

      static AduRadioButton()
      {
         ElementBase.DefaultStyle<AduRadioButton>(DefaultStyleKeyProperty);
      }

      #region AduSkin
      public Visibility IconVisibility
      {
         get { return (Visibility)GetValue(IconVisibilityProperty); }
         set { SetValue(IconVisibilityProperty, value); }
      }

      public static readonly DependencyProperty IconVisibilityProperty =
          DependencyProperty.Register("IconVisibility", typeof(Visibility), typeof(AduRadioButton));


      public Geometry Icon
      {
         get { return (Geometry)GetValue(IconProperty); }
         set { SetValue(IconProperty, value); }
      }

      public static readonly DependencyProperty IconProperty =
          DependencyProperty.Register("Icon", typeof(Geometry), typeof(AduRadioButton));

      public double IconWidth
      {
         get { return (double)GetValue(IconWidthProperty); }
         set { SetValue(IconWidthProperty, value); }
      }

      public static readonly DependencyProperty IconWidthProperty =
          DependencyProperty.Register("IconWidth", typeof(double), typeof(AduRadioButton), new PropertyMetadata(20.0));

      public double IconHeight
      {
         get { return (double)GetValue(IconHeightProperty); }
         set { SetValue(IconHeightProperty, value); }
      }

      public static readonly DependencyProperty IconHeightProperty =
          DependencyProperty.Register("IconHeight", typeof(double), typeof(AduRadioButton), new PropertyMetadata(20.0));

      #endregion
   }
}
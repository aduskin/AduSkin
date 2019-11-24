using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduDIYRadionButton : RadioButton
   {
      static AduDIYRadionButton()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduDIYRadionButton), new FrameworkPropertyMetadata(typeof(AduDIYRadionButton)));
      }
      #region AduSkin
      public Geometry IconNotChecked
      {
         get { return (Geometry)GetValue(IconNotCheckedProperty); }
         set { SetValue(IconNotCheckedProperty, value); }
      }

      public static readonly DependencyProperty IconNotCheckedProperty =
          DependencyProperty.Register("IconNotChecked", typeof(Geometry), typeof(AduDIYRadionButton));

      //-----------------
      public Geometry IconChecked
      {
         get { return (Geometry)GetValue(IconCheckedProperty); }
         set { SetValue(IconCheckedProperty, value); }
      }

      public static readonly DependencyProperty IconCheckedProperty =
          DependencyProperty.Register("IconChecked", typeof(Geometry), typeof(AduDIYRadionButton));

      public double IconWidth
      {
         get { return (double)GetValue(IconWidthProperty); }
         set { SetValue(IconWidthProperty, value); }
      }

      public static readonly DependencyProperty IconWidthProperty =
          DependencyProperty.Register("IconWidth", typeof(double), typeof(AduDIYRadionButton), new PropertyMetadata(20.0));


     
      #endregion
   }
}

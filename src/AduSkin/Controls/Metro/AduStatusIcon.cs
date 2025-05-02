
using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls; 

namespace AduSkin.Controls.Metro
{
   public class AduStatusIcon : Control
   {
      static AduStatusIcon()
      {
         ElementBase.DefaultStyle<AduStatusIcon>(DefaultStyleKeyProperty);
      }
       
      public static readonly DependencyProperty StatusTypeProperty = DependencyProperty.Register(
            "StatusType", typeof(StatusType), typeof(AduStatusIcon), new PropertyMetadata(default(StatusType)));

      public StatusType StatusType
      {
         get => (StatusType)GetValue(StatusTypeProperty);
         set => SetValue(StatusTypeProperty, value);
      }
   }
}
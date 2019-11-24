using AduSkin.Controls.Metro.Base;
using AduSkin.Utility.Element;
using System.Windows;

namespace AduSkin.Controls.Metro
{
   public class AduButtonRemind : AduButtonBase
   {
      public AduButtonRemind()
      {
         Utility.Refresh(this);
      }

      static AduButtonRemind()
      {
         ElementBase.DefaultStyle<AduButtonRemind>(DefaultStyleKeyProperty);
      }

      #region AduSkin
      public static readonly DependencyProperty AduButtonStateProperty = ElementBase.Property<AduButtonRemind, ButtonState>("AduButtonStateProperty", ButtonState.None);
      public ButtonState AduButtonState { get { return (ButtonState)GetValue(AduButtonStateProperty); } set { SetValue(AduButtonStateProperty, value); } }
      
      public string Hint
      {
         get { return (string)GetValue(HintProperty); }
         set { SetValue(HintProperty, value); }
      }

      public static readonly DependencyProperty HintProperty =
          DependencyProperty.Register("Hint", typeof(string), typeof(AduButtonRemind));
      #endregion
   }
}
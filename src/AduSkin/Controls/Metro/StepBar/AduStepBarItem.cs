 using System.Windows.Controls;
using System.Windows;
using AduSkin.Utility.Element;

namespace AduSkin.Controls.Metro
{ 
   public class AduStepBarItem : ContentControl
   {
      static AduStepBarItem()
      {
         ElementBase.DefaultStyle<AduStepBarItem>(DefaultStyleKeyProperty); 
      }
      /// <summary>
      /// 编号
      /// </summary>
      public string Number { get { return (string)GetValue(NumberProperty); } set { SetValue(NumberProperty, value); } } 
      public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(string), typeof(AduStepBarItem));  
   }
}

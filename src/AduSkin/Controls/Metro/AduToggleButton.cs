using AduSkin.Utility.Element;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduToggleButton : ToggleButton
   {
      static AduToggleButton()
      {
         ElementBase.DefaultStyle<AduToggleButton>(DefaultStyleKeyProperty);
      }
   }
}

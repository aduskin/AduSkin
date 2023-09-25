using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   /// <summary>
   /// 只有图标的按钮（不显示按钮文本）
   /// </summary>
   public class AduPathIconButton : Button
   {
      static AduPathIconButton()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduPathIconButton), new FrameworkPropertyMetadata(typeof(AduPathIconButton)));
      }
   }
}

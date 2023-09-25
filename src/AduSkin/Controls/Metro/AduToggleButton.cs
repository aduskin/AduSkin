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
      #region Private属性

      #endregion

      #region 依赖属性定义
      public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius"
          , typeof(CornerRadius), typeof(AduToggleButton));
      /// <summary>
      /// 边框圆角
      /// </summary>
      public CornerRadius CornerRadius
      {
         get { return (CornerRadius)GetValue(CornerRadiusProperty); }
         set { SetValue(CornerRadiusProperty, value); }
      } 
      #endregion

      #region Constructors
      static AduToggleButton()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduToggleButton), new FrameworkPropertyMetadata(typeof(AduToggleButton)));
      }
      #endregion

      #region 依赖属性set get

      #endregion

      #region Override方法

      #endregion

      #region Private方法

      #endregion
   }
}

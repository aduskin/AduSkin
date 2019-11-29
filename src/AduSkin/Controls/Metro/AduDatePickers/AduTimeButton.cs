using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace AduSkin.Controls.Metro
{
    public class AduTimeButton : ListBoxItem
    {
      public AduTimeButton()
      {
         Utility.Refresh(this);
      }

      #region Private属性
      #endregion

      #region 依赖属性定义

      #endregion

      #region 依赖属性set get

      #endregion

      #region Constructors
      static AduTimeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduTimeButton), new FrameworkPropertyMetadata(typeof(AduTimeButton)));
        }
        #endregion

        #region Override方法
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
        #endregion

        #region Private方法

        #endregion
    }
}

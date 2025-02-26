using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
   /// <summary>
   /// 右上角角标控件
   /// </summary>
   public class AduBadge : Control
   {
      #region 依赖属性定义
      public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number"
          , typeof(int), typeof(AduBadge), new FrameworkPropertyMetadata(0));

      public static readonly DependencyProperty IsDotProperty;

      #endregion

      #region 依赖属性set get
      /// <summary>
      /// 获取或者设置角标中显示的数字
      /// </summary>
      public int Number
      {
         get { return (int)GetValue(NumberProperty); }
         set { SetValue(NumberProperty, value); }
      }

      /// <summary>
      /// 获取或者设置角标的样式是否显示成一个圆点
      /// </summary>
      public bool IsDot
      {
         get { return (bool)GetValue(IsDotProperty); }
         set { SetValue(IsDotProperty, value); }
      }
      #endregion

      #region Constructors
      static AduBadge()
      {
         ElementBase.DefaultStyle<AduBadge>(DefaultStyleKeyProperty);

         IsDotProperty = DependencyProperty.Register("IsDot", typeof(bool), typeof(AduBadge), new FrameworkPropertyMetadata(false));
      }

      public AduBadge()
      {

      }
      #endregion 
   }
}

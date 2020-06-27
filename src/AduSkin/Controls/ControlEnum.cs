using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AduSkin.Controls
{
   #region EnumDatePickerType
   public enum EnumDatePickerType
   {
      /// <summary>
      /// 单个日期
      /// </summary>
      SingleDate,
      /// <summary>
      /// 连续的多个日期
      /// </summary>
      SingleDateRange,
      /// <summary>
      /// 只显示年份
      /// </summary>
      Year,
      /// <summary>
      /// 只显示月份
      /// </summary>
      Month,
      /// <summary>
      /// 显示一个日期和时间
      /// </summary>
      DateTime,
      /// <summary>
      /// 显示连续的日期和时间
      /// </summary>
      DateTimeRange,
   }
   #endregion

   #region FlatButtonSkinEnum
   /// <summary>
   /// Button类型
   /// </summary>
   public enum FlatButtonSkinEnum
   {
      Yes,
      No,
      Default,
      primary,
      ghost,
      dashed,
      text,
      info,
      success,
      error,
      warning,
   }
   #endregion

   #region EnumPromptType
   /// <summary>
   /// 提示类型
   /// </summary>
   public enum EnumPromptType
   {
      /// <summary>
      /// 消息
      /// </summary>
      Info,
      /// <summary>
      /// 警告
      /// </summary>
      Warn,
      /// <summary>
      /// 失败
      /// </summary>
      Error,
      /// <summary>
      /// 成功
      /// </summary>
      Success,
   }
   #endregion

   /// <summary>
   /// 加载类型
   /// </summary>
   #region EnumLoadingType
   public enum EnumLoadingType
   {
      /// <summary>
      /// 两个圆
      /// </summary>
      DoubleRound,
      /// <summary>
      /// 一个圆
      /// </summary>
      SingleRound,
      /// <summary>
      /// 仿Win10加载条
      /// </summary>
      Win10,
      /// <summary>
      /// 仿Android加载条
      /// </summary>
      Android,
      /// <summary>
      /// 仿苹果加载条
      /// </summary>
      Apple,
      Cogs,
      Normal,
      /// <summary>
      /// 线条动画
      /// </summary>
      Lines,
      /// <summary>
      /// 方格动画
      /// </summary>
      Grids,
      /// <summary>
      /// 中心旋转动画
      /// </summary>
      Rotate,
      /// <summary>
      /// 版块加载
      /// </summary>
      Block,
      /// <summary>
      /// 自定义图标动画
      /// </summary>
      PathAnimation
   }
   #endregion

   /// <summary>
   /// 方向
   /// </summary>
   #region EnumPlacement 
   public enum EnumPlacement
   {
      /// <summary>
      /// 左上
      /// </summary>
      LeftTop,
      /// <summary>
      /// 左中
      /// </summary>
      LeftCenter,
      /// <summary>
      /// 左下
      /// </summary>
      LeftBottom,
      /// <summary>
      /// 右上
      /// </summary>
      RightTop,
      /// <summary>
      /// 右中
      /// </summary>
      RightCenter,
      /// <summary>
      /// 右下
      /// </summary>
      RightBottom,
      /// <summary>
      /// 上左
      /// </summary>
      TopLeft,
      /// <summary>
      /// 上中
      /// </summary>
      TopCenter,
      /// <summary>
      /// 上右
      /// </summary>
      TopRight,
      /// <summary>
      /// 下左
      /// </summary>
      BottomLeft,
      /// <summary>
      /// 下中
      /// </summary>
      BottomCenter,
      /// <summary>
      /// 下右
      /// </summary>
      BottomRight,
   }
   #endregion

   /// <summary>
   /// 动画容器类型
   /// </summary>
   public enum TransitionMode
   {
      Right2Left,
      Left2Right,
      Bottom2Top,
      Top2Bottom,
      Right2LeftWithFade,
      Left2RightWithFade,
      Bottom2TopWithFade,
      Top2BottomWithFade,
      Fade,
      Custom
   }
   /// <summary>
   /// 联系人类型
   /// </summary>
   public enum ContactType
   {
      SerialNumber,
      Single,
      Group,
      AddUser,
      CutUser
   }
   /// <summary>
   /// 进度条类型
   /// </summary>
   public enum ProgressBarType
   {
      Line,
      Round
   }
   /// <summary>
   /// XAML显示类型
   /// </summary>
   public enum Scope
   {
      None,
      This,
      ThisAndChildren
   }
   /// <summary>
   /// 加减数字控件
   /// </summary>
   public enum EnumCompare
   {
      /// <summary>
      /// 小于
      /// </summary>
      Less,
      /// <summary>
      /// 等于
      /// </summary>
      Equal,
      /// <summary>
      /// 大于
      /// </summary>
      Large,
      None,
   }
   /// <summary>
   /// 通知图片类型
   /// </summary>
   public enum NotifyIconInfoType
   {
      /// <summary>
      ///  No Icon.
      /// </summary>
      None,

      /// <summary>
      ///  A Information Icon.
      /// </summary>
      Info,

      /// <summary>
      ///  A Warning Icon.
      /// </summary>
      Warning,

      /// <summary>
      ///  A Error Icon.
      /// </summary>
      Error
   }
   public enum EnumChooseBoxType
   {
      /// <summary>
      /// 单文件
      /// </summary>
      SingleFile,
      /// <summary>
      /// 多文件
      /// </summary>
      MultiFile,
      /// <summary>
      /// 文件夹
      /// </summary>
      Folder,
   }
}

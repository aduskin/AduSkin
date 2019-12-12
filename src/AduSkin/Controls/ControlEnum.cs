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
      Lines
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
}

using System.Windows.Forms;

namespace AduSkin.Utility.Computer
{
    public class Screen
    {

        static Screen()
        {
            var presentationSource = System.Windows.PresentationSource.FromVisual(System.Windows.Application.Current.MainWindow);
            if (presentationSource.CompositionTarget != null)
            {
                var m = presentationSource.CompositionTarget.TransformToDevice;
                ScaleFactorX = m.M11;
                ScaleFactorY = m.M22;
            }
        }

        /// <summary>
        /// 系统DPI的X缩放比
        /// </summary>
        public static double ScaleFactorX
        {
            get
            {
                return 1.0;
            }
            set
            {
                ScaleFactorX = value;
            }
        }// = 1.0;

        /// <summary>
        /// 系统DPI的Y缩放比
        /// </summary>
        public static double ScaleFactorY
        {
            get
            {
                return 1.0;
            }
            set
            {
                ScaleFactorY = value;
            }
        } //= 1.0;

        /// <summary>
        /// 屏幕逻辑宽度
        /// </summary>
        public static double ScreenWidthLogic = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / ScaleFactorX;

        /// <summary>
        /// 屏幕逻辑高度
        /// </summary>
        public static double ScreenHeightLogic = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / ScaleFactorY;

        /// <summary>
        /// 屏幕宽度
        /// </summary>
        public static double ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

        /// <summary>
        /// 屏幕高度
        /// </summary>
        public static double ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

        /// <summary>
        /// 工作区宽度
        /// </summary>
        public static double WorkWidth = SystemInformation.WorkingArea.Width;

        /// <summary>
        /// 工作区高度
        /// </summary>
        public static double WorkHeight = SystemInformation.WorkingArea.Height;

        /// <summary>
        /// 工作区左边
        /// </summary>
        public static double WorkLeft = SystemInformation.WorkingArea.X;

        /// <summary>
        /// 工作区顶部
        /// </summary>
        public static double WorkTop = SystemInformation.WorkingArea.Y;

        /// <summary>
        /// 获取任务栏宽度
        /// </summary>
        /// <returns></returns>
        public static double TaskBarWidth()
        {
            switch (GetTaskBarPostion())
            {
                case TaskBarPostion.Left:
                    return ScreenWidth - WorkWidth;
                case TaskBarPostion.Top:
                    return ScreenHeight - WorkHeight;
                case TaskBarPostion.Right:
                    return ScreenWidth - WorkWidth;
                case TaskBarPostion.Bottom:
                    return ScreenHeight - WorkHeight;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 获取任务栏高度
        /// </summary>
        /// <returns></returns>
        public static double TaskBarHeight()
        {
            switch (GetTaskBarPostion())
            {
                case TaskBarPostion.Left:
                    return ScreenHeight;
                case TaskBarPostion.Top:
                case TaskBarPostion.Right:
                    return ScreenHeight;
                case TaskBarPostion.Bottom:
                    return ScreenWidth;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 获取任务栏位置
        /// </summary>
        /// <returns></returns>
        public static TaskBarPostion GetTaskBarPostion()
        {
            if (WorkLeft > 0 && WorkTop == 0 && ScreenWidth - WorkWidth > 0 && ScreenHeight == WorkHeight)
                return TaskBarPostion.Left;
            else if (WorkLeft == 0 && WorkTop > 0 && ScreenWidth == WorkWidth && ScreenHeight - WorkHeight > 0)
                return TaskBarPostion.Top;
            else if (WorkLeft == 0 && WorkTop == 0 && ScreenWidth - WorkWidth > 0 && ScreenHeight == WorkHeight)
                return TaskBarPostion.Right;
            else if (WorkLeft == 0 && WorkTop == 0 && ScreenWidth == WorkWidth && ScreenHeight - WorkHeight > 0)
                return TaskBarPostion.Bottom;
            else
                return TaskBarPostion.Hide;
        }
    }
}
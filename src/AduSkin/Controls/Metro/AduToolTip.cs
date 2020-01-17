using System;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class AduToolTip : ToolTip
    {
        #region Private属性
        private EnumPlacement mPlacement;
        #endregion

        #region 依赖属性定义
        public static readonly DependencyProperty PlacementExProperty = DependencyProperty.Register("PlacementEx"
            , typeof(EnumPlacement), typeof(AduToolTip), new PropertyMetadata(EnumPlacement.TopLeft));
        public static readonly DependencyProperty IsShowShadowProperty = DependencyProperty.Register("IsShowShadow"
            , typeof(bool), typeof(AduToolTip), new PropertyMetadata(true));
        #endregion

        #region 依赖属性set get
        /// <summary>
        /// 鼠标按下时按钮的背景色
        /// </summary>
        public EnumPlacement PlacementEx
        {
            get { return (EnumPlacement)GetValue(PlacementExProperty); }
            set { SetValue(PlacementExProperty, value); }
        }

        /// <summary>
        /// 是否显示阴影
        /// </summary>
        public bool IsShowShadow
        {
            get { return (bool)GetValue(IsShowShadowProperty); }
            set { SetValue(IsShowShadowProperty, value); }
        }
        #endregion

        #region Constructors
        static AduToolTip()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduToolTip), new FrameworkPropertyMetadata(typeof(AduToolTip)));
        }
        #endregion

        #region Override方法
        public AduToolTip()
        {
         Utility.Refresh(this);
         this.Initialized += (o, e) =>
            {
                this.mPlacement = this.PlacementEx;
            };
        }

        protected override void OnOpened(RoutedEventArgs e)
        {
            //当在原本设置的位置显示Tooptip时，发现位置不够，重新设置ToopTip的Placement
            if(this.PlacementTarget != null)
            {
                double workAreaX = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
                double workAreaY = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度

                FrameworkElement control = this.PlacementTarget as FrameworkElement;
                double controlWidth = control.ActualWidth;
                double controlHeight = control.ActualHeight;

                Point p = this.PlacementTarget.PointFromScreen(new Point(0, 0));
                if(p != null)
                {
                    double pointX = Math.Abs(p.X); //得到控件在屏幕中的X坐标
                    double pointY = Math.Abs(p.Y);

                    switch (this.mPlacement)
                    {
                        case EnumPlacement.LeftTop:
                            this.SetLeftPosition(pointX, EnumPlacement.RightTop);
                            break;
                        case EnumPlacement.LeftBottom:
                            this.SetLeftPosition(pointX, EnumPlacement.RightBottom);
                            break;
                        case EnumPlacement.LeftCenter:
                            this.SetLeftPosition(pointX, EnumPlacement.RightCenter);
                            break;
                        case EnumPlacement.RightTop:
                            SetRightPosition(workAreaX, controlWidth, pointX, EnumPlacement.LeftTop);
                            break;
                        case EnumPlacement.RightBottom:
                            SetRightPosition(workAreaX, controlWidth, pointX, EnumPlacement.LeftBottom);
                            break;
                        case EnumPlacement.RightCenter:
                            SetRightPosition(workAreaX, controlWidth, pointX, EnumPlacement.LeftCenter);
                            break;
                        case EnumPlacement.TopLeft:
                            this.SetTopPosition(pointY, EnumPlacement.BottomLeft);
                            break;
                        case EnumPlacement.TopCenter:
                            this.SetTopPosition(pointY, EnumPlacement.BottomCenter);
                            break;
                        case EnumPlacement.TopRight:
                            this.SetTopPosition(pointY, EnumPlacement.BottomRight);
                            break;
                        case EnumPlacement.BottomLeft:
                            SetBottomPosition(workAreaY, controlHeight, pointY, EnumPlacement.TopLeft);
                            break;
                        case EnumPlacement.BottomCenter:
                            SetBottomPosition(workAreaY, controlHeight, pointY, EnumPlacement.TopCenter);
                            break;
                        case EnumPlacement.BottomRight:
                            SetBottomPosition(workAreaY, controlHeight, pointY, EnumPlacement.TopRight);
                            break;
                        default:
                            break;
                    }
                }
            }
            base.OnOpened(e);
        }

        #endregion;

        #region Private方法
        private void SetBottomPosition(double workAreaY, double controlHeight, double pointY, EnumPlacement placement)
        {
            if (workAreaY - (pointY + controlHeight) < this.ActualHeight)
            {
                this.PlacementEx = placement;
            }
            else
            {
                this.PlacementEx = this.mPlacement;
            }
        }

        private void SetTopPosition(double pointY, EnumPlacement placement)
        {
            if (pointY < this.ActualHeight)
            {
                this.PlacementEx = placement;
            }
            else
            {
                this.PlacementEx = this.mPlacement;
            }
        }

        private void SetRightPosition(double workAreaX, double controlWidth, double pointX, EnumPlacement placement)
        {
            if (workAreaX - (pointX + controlWidth) < this.ActualWidth)
            {
                this.PlacementEx = placement;
            }
            else
            {
                this.PlacementEx = this.mPlacement;
            }
        }

        private void SetLeftPosition(double pointX, EnumPlacement placement)
        {
            if (pointX < this.ActualWidth)
            {
                this.PlacementEx = placement;
            }
            else
            {
                this.PlacementEx = this.mPlacement;
            }
        }
        #endregion
    }
}
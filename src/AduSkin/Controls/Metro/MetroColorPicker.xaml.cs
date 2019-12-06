using AduSkin.Utility.Media;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public partial class MetroColorPicker : UserControl
    {
        public event EventHandler ColorChange;

        public Brush DefaultColor { get { return defaultColor.SolidColorBrush; } set { defaultColor = new HsbaColor(value); } }
        public RgbaColor CurrentColor { get { return currentColor.RgbaColor; } }

        private HsbaColor currentColor { get; set; }
        private RgbaColor currentRgbaColor { get; set; }
        private HsbaColor defaultColor = new HsbaColor(0.0, 0.0, 0.0, 1.0);
        private HsbaColor selectColor = new HsbaColor(0, 1.0, 1.0, 1.0);

        public double ButtonBorderThickness
        {
            get { return button.BorderThickness; }
            set { button.BorderThickness = button.MouseMoveBorderThickness = value; }
        }

        public Brush ButtonBorderBrush
        {
            get { return button.BorderBrush; }
            set { button.BorderBrush = button.MouseMoveBorderBrush = value; }
        }

        private bool canTransparent = true;

        public bool CanTransparent
        {
            get { return canTransparent; }
            set
            {
                canTransparent = value;
                alpha1.IsEnabled = rgbaA.IsEnabled = hsbaA.IsEnabled = value;
                if (!value)
                {
                    rgbaA.Text = "255";
                    hex.MaxLength = 7;
                }
                else
                {
                    hex.MaxLength = 9;
                }
            }
        }

        public MetroColorPicker()
        {
            InitializeComponent();
            Loaded += delegate { Initialize(Background == null ? new HsbaColor(0.0, 1.0, 1.0, 1.0) : new HsbaColor(Background)); };
        }

        public MetroColorPicker(string hexColor)
        {
            InitializeComponent();
            Loaded += delegate { Initialize(new HsbaColor(hexColor)); };
        }

        public MetroColorPicker(int r, int g, int b, int a)
        {
            InitializeComponent();
            Loaded += delegate { Initialize(new HsbaColor(r, g, b, a)); };
        }

        public Action ColorPickerClosed { get; set; }

        private void Initialize(HsbaColor hsbaColor)
        {
            // 绑定主题
            Utility.Refresh(this);

            // 设置当前初始颜色
            currentColor = hsbaColor;
            // defaultColor = currentColor;

            // 界面初始化
            viewDefColor.Background = defaultColor.SolidColorBrush;
            viewLine1.Offset = 1.0 / 6.0 * 0.0;
            viewLine2.Offset = 1.0 / 6.0 * 1.0;
            viewLine3.Offset = 1.0 / 6.0 * 2.0;
            viewLine4.Offset = 1.0 / 6.0 * 3.0;
            viewLine5.Offset = 1.0 / 6.0 * 4.0;
            viewLine6.Offset = 1.0 / 6.0 * 5.0;
            viewLine7.Offset = 1.0 / 6.0 * 6.0;

            // 按钮事件
            bool start = true;
            button.Click += delegate
            {
                polygon.Margin = new Thickness(ActualWidth / 2 - 5, -5.0, 0.0, 0.0);
                popup.IsOpen = true;
                if (start)
                {
                    ApplyColor(currentColor);
                    start = false;
                }
            };
            popup.Closed += delegate { if (ColorPickerClosed != null) ColorPickerClosed(); };
            viewDefColor.Click += delegate { ApplyColor(new HsbaColor(viewDefColor.Background)); };
            hex.ButtonClick += delegate { Clipboard.SetText(hex.Text); };

            // 视图被改变事件
            thumbSB.ValueChange += delegate { if (thumbSB.IsDragging) ViewChange(); };
            thumbH.ValueChange += delegate { if (thumbH.IsDragging) ViewChange(); };
            thumbA.ValueChange += delegate { if (thumbA.IsDragging) ViewChange(); };

            // RGBA操作事件
            rgbaR.TextChanged += delegate { if (rgbaR.IsSelectionActive) RgbaChange(); };
            rgbaG.TextChanged += delegate { if (rgbaG.IsSelectionActive) RgbaChange(); };
            rgbaB.TextChanged += delegate { if (rgbaB.IsSelectionActive) RgbaChange(); };
            rgbaA.TextChanged += delegate { if (rgbaA.IsSelectionActive) RgbaChange(); };

            // HSBA操作事件
            hsbaH.TextChanged += delegate { if (hsbaH.IsSelectionActive) HsbaChange(); };
            hsbaS.TextChanged += delegate { if (hsbaS.IsSelectionActive) HsbaChange(); };
            hsbaB.TextChanged += delegate { if (hsbaB.IsSelectionActive) HsbaChange(); };
            hsbaA.TextChanged += delegate { if (hsbaA.IsSelectionActive) HsbaChange(); };

            // HEX操作事件
            hex.TextChanged += delegate { if (hex.IsSelectionActive) HexChange(); };
        }

        private void ViewChange()
        {
            ApplyColor(new HsbaColor(360.0 * thumbH.YPercent, thumbSB.XPercent, Math.Abs(1 - thumbSB.YPercent), Math.Abs(1 - thumbA.YPercent)));
        }

        private void RgbaChange()
        {
            var doubleRgbaR = ConvertDouble(rgbaR.Text);
            var doubleRgbaG = ConvertDouble(rgbaG.Text);
            var doubleRgbaB = ConvertDouble(rgbaB.Text);
            var doubleRgbaA = ConvertDouble(rgbaA.Text);
            if (doubleRgbaR > 255) { rgbaR.Text = "255"; } else if (doubleRgbaR == -1) { rgbaR.Text = "0"; };
            if (doubleRgbaG > 255) { rgbaG.Text = "255"; } else if (doubleRgbaG == -1) { rgbaG.Text = "0"; };
            if (doubleRgbaB > 255) { rgbaB.Text = "255"; } else if (doubleRgbaB == -1) { rgbaB.Text = "0"; };
            if (doubleRgbaA > 255) { rgbaA.Text = "255"; } else if (doubleRgbaA == -1) { rgbaA.Text = "0"; };

            ApplyColor(new HsbaColor(ConvertInt(rgbaR.Text), ConvertInt(rgbaG.Text), ConvertInt(rgbaB.Text), ConvertInt(rgbaA.Text)));
        }

        private void HsbaChange()
        {
            var doubleHsbaH = ConvertDouble(hsbaH.Text);
            var doubleHsbaS = ConvertDouble(hsbaS.Text);
            var doubleHsbaB = ConvertDouble(hsbaB.Text);
            var doubleHsbaA = ConvertDouble(hsbaA.Text);
            if (doubleHsbaH > 100) { hsbaH.Text = "100"; } else if (doubleHsbaH == -1) { hsbaH.Text = "0"; };
            if (doubleHsbaS > 100) { hsbaS.Text = "100"; } else if (doubleHsbaS == -1) { hsbaS.Text = "0"; };
            if (doubleHsbaB > 100) { hsbaB.Text = "100"; } else if (doubleHsbaB == -1) { hsbaB.Text = "0"; };
            if (doubleHsbaA > 100) { hsbaA.Text = "100"; } else if (doubleHsbaA == -1) { hsbaA.Text = "0"; };

            ApplyColor(new HsbaColor(ConvertDouble(hsbaH.Text) * 3.6, ConvertDouble(hsbaS.Text) / 100.0, ConvertDouble(hsbaB.Text) / 100.0, ConvertDouble(hsbaA.Text) / 100.0));
        }

        private void HexChange()
        {
            ApplyColor(new HsbaColor(hex.Text));
        }

        private void ApplyColor(HsbaColor hsba)
        {
            currentColor = hsba;
            currentRgbaColor = currentColor.RgbaColor;

            if (!rgbaR.IsSelectionActive) { rgbaR.Text = currentRgbaColor.R.ToString(); }
            if (!rgbaG.IsSelectionActive) { rgbaG.Text = currentRgbaColor.G.ToString(); }
            if (!rgbaB.IsSelectionActive) { rgbaB.Text = currentRgbaColor.B.ToString(); }
            if (!rgbaA.IsSelectionActive) { rgbaA.Text = currentRgbaColor.A.ToString(); }

            if (!hsbaH.IsSelectionActive) { hsbaH.Text = ((int)(currentColor.H / 3.6)).ToString(); }
            if (!hsbaS.IsSelectionActive) { hsbaS.Text = ((int)(currentColor.S * 100)).ToString(); }
            if (!hsbaB.IsSelectionActive) { hsbaB.Text = ((int)(currentColor.B * 100)).ToString(); }
            if (!hsbaA.IsSelectionActive) { hsbaA.Text = ((int)(currentColor.A * 100)).ToString(); }

            if (!hex.IsSelectionActive) { if (canTransparent) { hex.Text = currentColor.HexString; } else { hex.Text = string.Format("#{0:X2}{1:X2}{2:X2}", currentRgbaColor.R, currentRgbaColor.G, currentRgbaColor.B); } }

            if (!thumbH.IsDragging) { thumbH.YPercent = currentColor.H / 360.0; }
            if (!thumbSB.IsDragging) { thumbSB.XPercent = currentColor.S; thumbSB.YPercent = 1 - currentColor.B; }
            if (!thumbA.IsDragging) { thumbA.YPercent = Math.Abs(1 - currentColor.A); }

            selectColor.H = currentColor.H;
            selectColor.A = currentColor.A;
            viewSelectColor.Fill = selectColor.OpaqueSolidColorBrush;
            if (canTransparent)
            {
                viewSelectColor.Opacity = viewSelectColor1.Opacity = viewSelectColor2.Opacity = 1 - thumbA.YPercent;
            }
            viewAlpha.Color = selectColor.OpaqueColor;
            if (canTransparent)
            {
                Background = currentColor.SolidColorBrush;
            }
            else
            {
                Background = currentColor.OpaqueSolidColorBrush;
            }
            if (ColorChange != null)
            {
               ColorChange.Invoke(this, null);
            }
        }

        private double ConvertDouble(string text)
        {
            try
            {
                return Convert.ToDouble(text);
            }
            catch
            {
                return -1;
            }
        }

        private int ConvertInt(string text)
        {
            try
            {
                return Convert.ToInt32(text);
            }
            catch
            {
                return -1;
            }
        }
    }
}
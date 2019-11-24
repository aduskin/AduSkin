using System.Windows.Media;

namespace AduSkin.Utility.Media
{
    public class HsbaColor
    {
        double h = 0, s = 0, b = 0, a = 0;
        /// <summary>
        /// 0 - 359，360 = 0
        /// </summary>
        public double H { get { return h; } set { h = value < 0 ? 0 : value >= 360 ? 0 : value; } }
        /// <summary>
        /// 0 - 1
        /// </summary>
        public double S { get { return s; } set { s = value < 0 ? 0 : value > 1 ? 1 : value; } }
        /// <summary>
        /// 0 - 1
        /// </summary>
        public double B { get { return b; } set { b = value < 0 ? 0 : value > 1 ? 1 : value; } }
        /// <summary>
        /// 0 - 1
        /// </summary>
        public double A { get { return a; } set { a = value < 0 ? 0 : value > 1 ? 1 : value; } }
        /// <summary>
        /// 亮度 0 - 100
        /// </summary>
        public int Y { get { return RgbaColor.Y; } }

        public HsbaColor() { H = 0; S = 0; B = 1; A = 1; }
        public HsbaColor(double h, double s, double b, double a = 1) { H = h; S = s; B = b; A = a; }
        public HsbaColor(int r, int g, int b, int a = 255)
        {
            HsbaColor hsba = Utility.RgbaToHsba(new RgbaColor(r, g, b, a));
            H = hsba.H;
            S = hsba.S;
            B = hsba.B;
            A = hsba.A;
        }
        public HsbaColor(Brush brush)
        {
            HsbaColor hsba = Utility.RgbaToHsba(new RgbaColor(brush));
            H = hsba.H;
            S = hsba.S;
            B = hsba.B;
            A = hsba.A;
        }
        public HsbaColor(string hexColor)
        {
            HsbaColor hsba = Utility.RgbaToHsba(new RgbaColor(hexColor));
            H = hsba.H;
            S = hsba.S;
            B = hsba.B;
            A = hsba.A;
        }


        public Color Color { get { return RgbaColor.Color; } }
        public Color OpaqueColor { get { return RgbaColor.OpaqueColor; } }
        public SolidColorBrush SolidColorBrush { get { return RgbaColor.SolidColorBrush; } }
        public SolidColorBrush OpaqueSolidColorBrush { get { return RgbaColor.OpaqueSolidColorBrush; } }

        public string HexString { get { return Color.ToString(); } }
        public string RgbaString { get { return RgbaColor.RgbaString; } }

        public RgbaColor RgbaColor { get { return Utility.HsbaToRgba(this); } }
    }
}
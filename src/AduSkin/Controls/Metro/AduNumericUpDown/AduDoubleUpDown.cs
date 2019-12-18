using System;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    [TemplatePart(Name = "PART_ContentHost", Type = typeof(ScrollViewer))]
    [TemplatePart(Name = "PART_UP", Type = typeof(Button))]
    [TemplatePart(Name = "PART_DOWN", Type = typeof(Button))]
    public class AduDoubleUpDown : AduNumericUpDown<double>
    {
        public AduDoubleUpDown() : base()
        {
            this.Minimum = 0d;
            this.Maximum = 100d;
            this.Value = this.Minimum;
            this.Increment = 1d;
        }

        protected override double IncrementValue(double value, double increment)
        {
            return value + increment;
        }

        protected override double DecrementValue(double value, double increment)
        {
            return value - increment;
        }

        protected override double ParseValue(string value)
        {
            double temp = 0;
            if (double.TryParse(value, out temp))
            {
                return temp;
            }
            else
            {
                return double.MinValue;
            }
        }
    }
}

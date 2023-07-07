using System;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    [TemplatePart(Name = "PART_ContentHost", Type = typeof(ScrollViewer))]
    [TemplatePart(Name = "PART_UP", Type = typeof(Button))]
    [TemplatePart(Name = "PART_DOWN", Type = typeof(Button))]
    public class AduIntegerUpDown : AduNumericUpDown<int>
    {
        public AduIntegerUpDown() : base()
        {
            this.Minimum = 0;
            this.Maximum = 100;
            this.Value = this.Minimum;
            this.Increment = 1;
        } 

        protected override int IncrementValue(int value, int increment)
        {
            return value + increment;
        }

        protected override int DecrementValue(int value, int increment)
        {
            return value - increment;
        }

        protected override int ParseValue(string value)
        {
            int temp = 0;
            if(int.TryParse(value, out temp))
            {
                return temp;
            }
            else
            {
                return int.MinValue;
            }
        }
    }
}

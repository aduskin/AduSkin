using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AduSkin.Controls.Helper
{
    public class ColorHelper
   {
      public static Color ToColor(uint c)
      {
         var bytes = BitConverter.GetBytes(c);
         return Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
      }
   }
}

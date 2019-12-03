using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AduSkin.Controls.Data.Args
{
   public class CancelRoutedEventArgs : RoutedEventArgs
   {
      public CancelRoutedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
      {
      }

      public bool Cancel { get; set; }
   }
}

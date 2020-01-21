using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AduSkin.Controls.Data
{
   public class FunctionEventArgs<T> : RoutedEventArgs
   {
      public FunctionEventArgs(T info)
      {
         Info = info;
      }

      public FunctionEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
      {
      }

      public T Info { get; set; }
   }
}

using AduSkin.Utility.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
   public class AduTreeView : TreeView
   {
      static AduTreeView()
      {
         ElementBase.DefaultStyle<AduTreeView>(DefaultStyleKeyProperty);
      }
   }
}

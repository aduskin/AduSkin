using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AduSkin.Demo.Models
{
   public class ControlModel
   {
      public ControlModel(string title, Type content, string tags = "")
      {
         Title = title;
         Content = content;
         Tags = tags;
      }

      public ControlModel()
      {
         Tags = string.Empty;
      }

      public int Id { get; private set; }

      public string Title { get; set; }

      public Type Content { get; set; }

      public string Tags { get; set; }
   }
}

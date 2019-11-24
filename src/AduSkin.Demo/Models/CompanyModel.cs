using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AduSkin.Demo.Models
{
   public class CompanyModel
   {
      public bool IsGrouping { get; set; }
      public ObservableCollection<CompanyModel> Children { get; set; }
      public string DisplayName { get; set; }
      public string SurName { get; set; }
      public string Name { get; set; }
      public string Info { get; set; }
      public string State { get; set; }
   }
}

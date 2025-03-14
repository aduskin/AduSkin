using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AduSkin.Demo.ViewModel
{
   public partial class RunningBlockViewModel : ObservableObject
   {
      private string _RunningText = "AduSkin - 追求极致，永臻完美";
      /// <summary>
      /// 滚动字幕
      /// </summary>
      public string RunningText
      {
         get { return _RunningText; }
         set
         {
            _RunningText = value;
            OnPropertyChanged("RunningText");
         }
      }

      /// <summary>
      /// 刷新
      /// </summary>
      [RelayCommand]
      public void Update()
      {
         RunningText = $"AduSkin - {Guid.NewGuid().ToString()}";
      }
   }
}

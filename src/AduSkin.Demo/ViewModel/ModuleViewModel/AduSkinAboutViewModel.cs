using AduSkin.Demo.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AduSkin.Demo.ViewModel
{
   public class AduSkinAboutViewModel : ViewModelBase
   {
      /// <summary>
      /// 命令Command
      /// </summary>
      public ICommand OpenDemo => new RelayCommand<string>((e) =>
      {
         switch (e)
         {
            case "About":
               new AduSkinDemo().Show();
               return;
            case "Video":
               new AduVideoDemo().Show();
               return;
            case "Reward":
               IsOpenReward = true;
               return;
            default:
               break;
         }
      });


      private bool _IsOpenReward;
      /// <summary>
      /// 属性.
      /// </summary>
      public bool IsOpenReward
      {
         get { return _IsOpenReward; }
         set { Set(ref _IsOpenReward, value); }
      }
   }
}

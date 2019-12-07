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
            default:
               break;
         }
      });
   }
}

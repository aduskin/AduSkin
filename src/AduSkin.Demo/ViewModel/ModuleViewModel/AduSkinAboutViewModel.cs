using AduSkin.Demo.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace AduSkin.Demo.ViewModel
{
   public partial class AduSkinAboutViewModel : ObservableObject
   {
      /// <summary>
      /// 命令Command
      /// </summary>
      [RelayCommand]
      public void OpenDemo(string e)
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
         }
      }


      private bool _IsOpenReward;
      /// <summary>
      /// 属性.
      /// </summary>
      public bool IsOpenReward
      {
         get { return _IsOpenReward; }
         set { SetProperty(ref _IsOpenReward, value); }
      }
   }
}

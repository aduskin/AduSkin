using AduSkin.Controls;
using AduSkin.Controls.Metro;
using AduSkin.Demo.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AduSkin.Demo.ViewModel
{
   public class NoticeDemoViewModel: ViewModelBase
   {
      #region 右侧弹框
      /// <summary>
      /// 命令Command
      /// </summary>
      public ICommand OpenMsg => new RelayCommand<string>((e) =>
      {
         switch (e)
         {
            case "Error":
               NoticeManager.NotifiactionShow.AddNotifiaction(new NotifiactionModel()
               {
                  Title = "这是Error通知标题",
                  Content = "这条通知不会自动关闭，需要点击关闭按钮",
                  NotifiactionType = EnumPromptType.Error
               });
               return;
            case "Success":
               NoticeManager.NotifiactionShow.AddNotifiaction(new NotifiactionModel()
               {
                  Title = "这是Success通知标题",
                  Content = "这条通知不会自动关闭，需要点击关闭按钮这条通知不会自动关闭，需要点击关闭按钮这条通知不会自动关闭，需要点击关闭按钮",
                  NotifiactionType = EnumPromptType.Success
               });
               return;
            case "Warm":
               NoticeManager.NotifiactionShow.AddNotifiaction(new NotifiactionModel()
               {
                  Title = "这是Warn通知标题",
                  Content = "这条通知不会自动关闭，需要点击关闭按钮",
                  NotifiactionType = EnumPromptType.Warn
               });
               return;
            case "Info":
               NoticeManager.NotifiactionShow.AddNotifiaction(new NotifiactionModel()
               {
                  Title = "这是Info通知标题",
                  Content = "这条通知不会自动关闭"
               });
               return;
            default:
               break;
         }
      });
      #endregion
   }
}

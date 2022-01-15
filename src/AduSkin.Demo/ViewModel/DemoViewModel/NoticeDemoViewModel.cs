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
               NoticeManager.NotificationShow.AddNotification(new NotificationModel()
               {
                  Title = "这是Error通知标题",
                  Content = "这条通知不会自动关闭，需要点击关闭按钮",
                  NotificationType = EnumPromptType.Error
               });
               return;
            case "Success":
               NoticeManager.NotificationShow.AddNotification(new NotificationModel()
               {
                  Title = "这是Success通知标题",
                  Content = "这条通知不会自动关闭，需要点击关闭按钮这条通知不会自动关闭，需要点击关闭按钮这条通知不会自动关闭，需要点击关闭按钮",
                  NotificationType = EnumPromptType.Success
               });
               return;
            case "Warm":
               NoticeManager.NotificationShow.AddNotification(new NotificationModel()
               {
                  Title = "这是Warn通知标题",
                  Content = "这条通知不会自动关闭，需要点击关闭按钮",
                  NotificationType = EnumPromptType.Warn
               });
               return;
            case "Info":
               NoticeManager.NotificationShow.AddNotification(new NotificationModel()
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

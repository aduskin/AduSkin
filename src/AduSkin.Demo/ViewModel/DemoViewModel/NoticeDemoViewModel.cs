using AduSkin.Controls;
using AduSkin.Controls.Metro;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace AduSkin.Demo.ViewModel
{
   public partial class NoticeDemoViewModel : ObservableObject
   {
      #region 右侧弹框
      /// <summary>
      /// 命令Command
      /// </summary>
      [RelayCommand]
      public void OpenMsg(string e)
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
         }
      }
      #endregion
   }
}

using AduSkin.Controls.Metro;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace AduSkin.Demo.ViewModel
{
   public partial class MessageBoxDemoViewModel : ObservableObject
   {
      /// <summary>
      /// 命令Command
      /// </summary>
      [RelayCommand]
      private void OpenMessageBox(string e)
      {
         switch (e)
         {
            case "普通弹框":
               AduMessageBox.Show("AduSkin\n追求极致，永臻完美\n且随疾风前行，身后一许流星");
               break;
            case "普通弹框2":
               AduMessageBox.Show("AduSkin正在美化中！", "AduSkin 标题");
               break;
            case "确认取消弹框":
               AduMessageBox.Show("您是否继续支持AduSkin！", "AduSkin 标题", MessageBoxButton.OKCancel);
               break;
            case "带图标确认取消弹框":
               AduMessageBox.Show("您是否继续支持AduSkin！", "AduSkin 标题", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
               break;
            case "自定义弹框":
               MessageBoxResult result = AduMessageBox.ShowYesNoCancel(
                "您是否继续支持AduSkin？",
                "欢迎使用AduSkin!",
                "希望",
                "不希望",
                "暂不使用",
                MessageBoxImage.Exclamation);

               NoticeManager.NotificationShow.AddNotification(new NotificationModel()
               {
                  Title = "返回结果",
                  Content = result.ToString()
               });
               break;
            default:
               break;
         }
      } 
   }
}

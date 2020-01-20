using AduSkin.Controls.Metro;
using System.Windows;

namespace AduSkin.Demo
{
   public partial class App : Application
   {
      protected override void OnStartup(StartupEventArgs e)
      {
         var splashScreen = new SplashScreen("Resources/aduskin.png");
         splashScreen.Show(true);
         base.OnStartup(e);
         //初始化通知弹框
         NoticeManager.Initialize();
      }
      protected override void OnExit(ExitEventArgs e)
      {
         NoticeManager.ExitNotifiaction();
         base.OnExit(e);
      }
   }
}
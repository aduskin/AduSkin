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
      }
   }
}
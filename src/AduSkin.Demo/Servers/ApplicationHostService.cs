using AduSkin.Controls.Metro;
using AduSkin.Demo.Servers.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System; 
using System.Linq; 
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AduSkin.Demo.Servers
{
   public class ApplicationHostService : IHostedService
   {
      private readonly IServiceProvider _serviceProvider;
      public ApplicationHostService(IServiceProvider serviceProvider)
      {
         _serviceProvider = serviceProvider;
      }

      public Task StartAsync(CancellationToken cancellationToken)
      {
         if (Application.Current.Windows.OfType<MainWindow>().Any())
         {
            return Task.CompletedTask;
         }
         //启动封面
         var splashScreen = new SplashScreen("Resources/aduskin.png");
         splashScreen.Show(true);
         //主窗口
         IWindow mainWindow = _serviceProvider.GetRequiredService<IWindow>();
         mainWindow?.Show();
         //初始化通知弹框
         NoticeManager.Initialize();

         return Task.CompletedTask;
      }

      public Task StopAsync(CancellationToken cancellationToken)
      { 
         //退出
         NoticeManager.ExitNotification();
         return Task.CompletedTask;
      } 
   }
}

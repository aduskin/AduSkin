using AduSkin.Demo.Servers;
using AduSkin.Demo.Servers.Contracts;
using AduSkin.Demo.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using System.Windows;

namespace AduSkin.Demo
{
   public partial class App : Application
   {

      private static readonly IHost _host = Host.CreateDefaultBuilder()
          .ConfigureAppConfiguration(c =>
          {
             _ = c.SetBasePath(AppContext.BaseDirectory);
          })
         .ConfigureServices((context, services) =>
         {
            _ = services.AddHostedService<ApplicationHostService>();

            _ = services.AddSingleton<IWindow, MainWindow>();
            _ = services.AddSingleton<MainViewModel>();
         }).Build();
      public App()
      {
         Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
      }
      protected override void OnStartup(StartupEventArgs e)
      {
         _host.Start();
      }
      protected override void OnExit(ExitEventArgs e)
      {
         _host.StopAsync().Wait();
         _host.Dispose();
      }
   }
}
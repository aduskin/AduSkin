using AduSkin.Controls.Metro;
using System;
using System.IO;
using System.Windows;
namespace AduSkin.Demo.Views
{
   /// <summary>
   /// AduSkinDemo.xaml 的交互逻辑
   /// </summary>
   public partial class AduVideoDemo : AduWindow
   {
      public AduVideoDemo()
      {
         InitializeComponent();
      }

      private void AduWindow_Closed(object sender, EventArgs e)
      {
         if(videoPlayer.IsPlaying)
            this.videoPlayer.Stop();
      }
   }
}

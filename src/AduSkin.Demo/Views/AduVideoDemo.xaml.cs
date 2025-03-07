using AduSkin.Controls.Metro;
using System;

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

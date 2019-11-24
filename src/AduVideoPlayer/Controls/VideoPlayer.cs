using AduSkin.Controls.Metro;
using AduSkin.Utility.AduMethod;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;
using Vlc.DotNet.Wpf;

namespace AduVideoPlayer.Controls
{
   public class VideoPlayer : Control
   {
      private const int InitVolume = 200;

      #region Inner Controls
      private VlcControl PART_VlcControl;
      /// <summary>
      /// 播放按钮
      /// </summary>
      private Button PART_Btn_Play;
      /// <summary>
      /// 暂停按钮
      /// </summary>
      private Button PART_Btn_Pause;
      /// <summary>
      /// 停止按钮
      /// </summary>
      private Button PART_Btn_Stop;
      /// <summary>
      /// 下一个
      /// </summary>
      private Button PART_Btn_Next;
      /// <summary>
      /// 上一个
      /// </summary>
      private Button PART_Btn_Previous;
      /// <summary>
      /// 视频当前播放进度
      /// </summary>
      private Run PART_Time_Current;
      /// <summary>
      /// 视频总时长
      /// </summary>
      private Run PART_Time_Total;
      /// <summary>
      /// 视频时间显示文本
      /// </summary>
      private TextBlock PART_Video_Time;
      /// <summary>
      /// 底部操作区域
      /// </summary>
      private Border PART_Bottom_Tool;
      /// <summary>
      /// 视频进度条
      /// </summary>
      private AduFlatSilder PART_Slider;
      /// <summary>
      /// 快退按钮
      /// </summary>
      private Button PART_Btn_Slower;
      /// <summary>
      /// 快进按钮
      /// </summary>
      private Button PART_Btn_Faster;
      /// <summary>
      /// 加载中
      /// </summary>
      private AduLoading PART_Loading;
      /// <summary>
      /// 播放信息面板
      /// </summary>
      private Border PART_PlayInfo;
      private MetroTextBox PART_Txt_VideoSource;
      private AduFlatButton PART_Btn_PlayLocalFile;
      private AduFlatButton PART_Btn_PlayUri;
      private Button PART_Btn_OpenFile;
      /// <summary>
      /// 鼠标悬浮触发区域，用于触发地图操作区域的显示与隐藏
      /// </summary>
      private Border PART_MouseOver_Area;

      private Button PART_Btn_Screenshot;
      /// <summary>
      /// 音量
      /// </summary>
      private Slider PART_Volume_Slider;
      #endregion

      #region private fields
      /// <summary>
      /// 视频总长度
      /// </summary>
      private long _videoLength;
      /// <summary>
      /// 视频当前播放进度
      /// </summary>
      private long _currentPosition;
      private bool _isOverBottomTool;
      #endregion

      #region public fields

      #region VideoState
      public MediaStates VideoState
      {
         get
         {
            if (this.VlcIsNotNull())
            {
               return this.PART_VlcControl.SourceProvider.MediaPlayer.State;
            }
            return MediaStates.Stopped;
         }
      }

      #endregion

      #region IsVlcControlLoading
      private bool _IsVlcControlLoading;
      /// <summary>
      /// VLC是否正在初始化
      /// </summary>
      public bool IsVlcControlLoading
      {
         get { return _IsVlcControlLoading; }
         set { _IsVlcControlLoading = value; }
      }
      #endregion

      #region IsVideoLoading
      private bool _IsVideoLoading;
      /// <summary>
      /// 视频是否正在加载中
      /// </summary>
      public bool IsVideoLoading
      {
         get { return _IsVideoLoading; }
         set { _IsVideoLoading = value; }
      }

      #endregion

      #endregion

      #region 依赖属性

      #region IsPlaying
      public bool IsPlaying
      {
         get { return (bool)GetValue(IsPlayingProperty); }
         private set { SetValue(IsPlayingProperty, value); }
      }

      public static readonly DependencyProperty IsPlayingProperty =
          DependencyProperty.Register("IsPlaying", typeof(bool), typeof(VideoPlayer), new PropertyMetadata(false));
      #endregion

      #region Volume

      /// <summary>
      /// 音量
      /// </summary>
      public int Volume
      {
         get { return (int)GetValue(VolumeProperty); }
         set { SetValue(VolumeProperty, value); }
      }

      public static readonly DependencyProperty VolumeProperty =
          DependencyProperty.Register("Volume", typeof(int), typeof(VideoPlayer), new PropertyMetadata(InitVolume, new PropertyChangedCallback(VolumeChangedCallback)));

      private static void VolumeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         VideoPlayer videoPlayer = d as VideoPlayer;
         if (e.NewValue != null && videoPlayer != null && videoPlayer.VlcIsNotNull())
         {
            videoPlayer.GetVlcMediaPlayer().Audio.Volume = (int)e.NewValue;
         }
      }

      #endregion

      #region PlayList

      //public ObservableCollection<VideoInfo> PlayList
      //{
      //    get { return (ObservableCollection<VideoInfo>)GetValue(PlayListProperty); }
      //    set { SetValue(PlayListProperty, value); }
      //}

      //public static readonly DependencyProperty PlayListProperty =
      //    DependencyProperty.Register("PlayList", typeof(ObservableCollection<VideoInfo>), typeof(VideoPlayer), new PropertyMetadata(null));

      #endregion

      #endregion

      static VideoPlayer()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(VideoPlayer), new FrameworkPropertyMetadata(typeof(VideoPlayer)));
      }

      public override void OnApplyTemplate()
      {
         this.UnRegisterEvent();

         base.OnApplyTemplate();

         this.PART_VlcControl = this.GetTemplateChild("PART_VlcControl") as VlcControl;
         if (this.PART_VlcControl != null)
         {
            var vlcLibDirectory = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            var options = new string[]
            {
               // VLC options can be given here. Please refer to the VLC command line documentation.
            };

            Task.Run(() =>
            {
               Application.Current.Dispatcher.Invoke(() =>
               {
                   this.IsVlcControlLoading = true;
                });
               this.PART_VlcControl.SourceProvider.CreatePlayer(vlcLibDirectory, options);
            }).ContinueWith((t) =>
            {
               Application.Current.Dispatcher.Invoke(() =>
                   {
                   this.IsVlcControlLoading = false;
                   this.RegisterEvent();
                   if (this.PART_Volume_Slider != null)
                   {
                      this.PART_Volume_Slider.Maximum = InitVolume;
                      this.PART_Volume_Slider.Minimum = 0;
                      this.PART_Volume_Slider.Value = this.Volume;
                   }
                });
            });
         }

         this.PART_Btn_Play = this.GetTemplateChild("PART_Btn_Play") as Button;
         this.PART_Btn_Pause = this.GetTemplateChild("PART_Btn_Pause") as Button;
         this.PART_Btn_Stop = this.GetTemplateChild("PART_Btn_Stop") as Button;
         this.PART_Btn_Next = this.GetTemplateChild("PART_Btn_Next") as Button;
         this.PART_Btn_Previous = this.GetTemplateChild("PART_Btn_Previous") as Button;
         this.PART_Time_Current = this.GetTemplateChild("PART_Time_Current") as Run;
         this.PART_Time_Total = this.GetTemplateChild("PART_Time_Total") as Run;
         this.PART_Video_Time = this.GetTemplateChild("PART_Video_Time") as TextBlock;
         this.PART_Bottom_Tool = this.GetTemplateChild("PART_Bottom_Tool") as Border;
         this.PART_Slider = this.GetTemplateChild("PART_Slider") as AduFlatSilder;
         this.PART_Btn_Slower = this.GetTemplateChild("PART_Btn_Slower") as Button;
         this.PART_Btn_Faster = this.GetTemplateChild("PART_Btn_Faster") as Button;
         this.PART_MouseOver_Area = this.GetTemplateChild("PART_MouseOver_Area") as Border;
         this.PART_Volume_Slider = this.GetTemplateChild("PART_Volume_Slider") as Slider;
         this.PART_Loading = this.GetTemplateChild("PART_Loading") as AduLoading;
         //播放地址
         this.PART_PlayInfo = this.GetTemplateChild("PART_PlayInfo") as Border;
         this.PART_Txt_VideoSource = this.GetTemplateChild("PART_Txt_VideoSource") as MetroTextBox;
         this.PART_Btn_PlayLocalFile = this.GetTemplateChild("PART_Btn_PlayLocalFile") as AduFlatButton;
         this.PART_Btn_PlayUri = this.GetTemplateChild("PART_Btn_PlayUri") as AduFlatButton;
         this.PART_Btn_Screenshot = this.GetTemplateChild("PART_Btn_Screenshot") as Button;
         this.PART_Btn_OpenFile = this.GetTemplateChild("PART_Btn_OpenFile") as Button;
         this.VideoStoped();
      }

      /// <summary>
      /// 注册
      /// </summary>
      private void RegisterEvent()
      {
         if (this.VlcIsNotNull())
         {
            this.GetVlcMediaPlayer().LengthChanged += MediaPlayer_LengthChanged;
            this.GetVlcMediaPlayer().PositionChanged += MediaPlayer_PositionChanged;
            this.GetVlcMediaPlayer().Playing += MediaPlayer_Playing;
            this.GetVlcMediaPlayer().Paused += MediaPlayer_Paused;
            this.GetVlcMediaPlayer().Stopped += MediaPlayer_Stopped;
            this.GetVlcMediaPlayer().SnapshotTaken += VideoPlayer_SnapshotTaken;
         }

         if (this.PART_Btn_Play != null)
         {
            this.PART_Btn_Play.Click += PART_Btn_Play_Click;
         }

         if (this.PART_Btn_Pause != null)
         {
            this.PART_Btn_Pause.Click += PART_Btn_Pause_Click;
         }

         if (this.PART_Btn_Stop != null)
         {
            this.PART_Btn_Stop.Click += PART_Btn_Stop_Click;
         }

         if (this.PART_Btn_Next != null)
         {
            this.PART_Btn_Next.Click += PART_Btn_Next_Click;
         }

         if (this.PART_Btn_Previous != null)
         {
            this.PART_Btn_Previous.Click += PART_Btn_Previous_Click;
         }

         if (this.PART_Slider != null)
         {
            this.PART_Slider.DropValueChanged += PART_Slider_DropValueChanged;
         }

         if (this.PART_MouseOver_Area != null)
         {
            //this.PART_Bottom_Tool.AddHandler(Control.MouseEnterEvent, new MouseEventHandler(PART_MouseOver_Area_MouseEnter));
            //this.PART_Bottom_Tool.AddHandler(Control.MouseLeaveEvent, new MouseEventHandler(PART_MouseOver_Area_MouseLeave));
            this.PART_MouseOver_Area.MouseEnter += PART_MouseOver_Area_MouseEnter;
            this.PART_MouseOver_Area.MouseLeave += PART_MouseOver_Area_MouseLeave;
         }

         if (this.PART_Btn_Slower != null)
         {
            //this.PART_Btn_Slower.MouseLeftButtonDown += PART_Btn_Slower_MouseLeftButtonDown;
            //this.PART_Btn_Slower.MouseLeftButtonUp += PART_Btn_Slower_MouseLeftButtonUp;
            this.PART_Btn_Slower.Click += PART_Btn_Slower_Click;
         }

         if (this.PART_Btn_Faster != null)
         {
            //this.PART_Btn_Faster.MouseLeftButtonDown += PART_Btn_Faster_MouseLeftButtonDown;
            //this.PART_Btn_Faster.MouseLeftButtonUp += PART_Btn_Faster_MouseLeftButtonUp;
            this.PART_Btn_Faster.Click += PART_Btn_Faster_Click;
         }

         if (this.PART_Btn_Screenshot != null)
         {
            this.PART_Btn_Screenshot.Click += PART_Btn_Screenshot_Click;
         }

         if (this.PART_Btn_OpenFile != null)
         {
            this.PART_Btn_OpenFile.Click += PART_Btn_OpenFile_Click;
         }

         if (this.PART_Btn_PlayLocalFile != null)
         {
            this.PART_Btn_PlayLocalFile.Click += PART_Btn_PlayLocalFile_Click;
         }

         if (this.PART_Btn_PlayUri != null)
         {
            this.PART_Btn_PlayUri.Click += PART_Btn_PlayUri_Click;
         }
      }

      private void PART_Btn_Screenshot_Click(object sender, RoutedEventArgs e)
      {
         FileInfo fileInfo = new FileInfo(string.Format("{0}\\{1}.png", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd_HHmmss")));
         Task.Run(() =>
         {
            this.GetVlcMediaPlayer().TakeSnapshot(fileInfo);
         });
      }

      private void PART_Btn_OpenFile_Click(object sender, RoutedEventArgs e)
      {
         if (PART_PlayInfo != null)
         {
            if (PART_PlayInfo.Visibility == Visibility.Collapsed)
            {
               PART_PlayInfo.Visibility = Visibility.Visible;
            }
            else
            {
               PART_PlayInfo.Visibility = Visibility.Collapsed;
            }
         }
         
      }

      private void PART_Btn_Slower_Click(object sender, RoutedEventArgs e)
      {
         this.GetVlcMediaPlayer().Time = this.GetVlcMediaPlayer().Time >= 2000 ? this.GetVlcMediaPlayer().Time - 2000 : 0;
      }

      private void PART_Btn_Faster_Click(object sender, RoutedEventArgs e)
      {
         this.GetVlcMediaPlayer().Time = this.GetVlcMediaPlayer().Time + 2000 <= this._videoLength ? this.GetVlcMediaPlayer().Time + 2000 : this._videoLength;
      }

      private void SetRadio()
      {

      }

      private void PART_Btn_Faster_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
      {
         this.GetVlcMediaPlayer().Rate = 2;
      }

      private void PART_Btn_Faster_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {

      }

      private void PART_Btn_Slower_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
      {

      }

      private void PART_Btn_Slower_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {

      }

      private void UnRegisterEvent()
      {
         if (this.PART_Btn_Play != null)
         {
            this.PART_Btn_Play.Click -= PART_Btn_Play_Click;
         }

         if (this.PART_Btn_Pause != null)
         {
            this.PART_Btn_Pause.Click -= PART_Btn_Pause_Click;
         }

         if (this.PART_Btn_Stop != null)
         {
            this.PART_Btn_Stop.Click -= PART_Btn_Stop_Click;
         }

         if (this.PART_Btn_Next != null)
         {
            this.PART_Btn_Next.Click -= PART_Btn_Next_Click;
         }

         if (this.PART_Btn_Previous != null)
         {
            this.PART_Btn_Previous.Click -= PART_Btn_Previous_Click;
         }

         if (this.PART_Btn_PlayLocalFile != null)
         {
            this.PART_Btn_PlayLocalFile.Click -= PART_Btn_PlayLocalFile_Click;
         }

         if (this.PART_Btn_PlayUri != null)
         {
            this.PART_Btn_PlayUri.Click -= PART_Btn_PlayUri_Click;
         }
      }

      #region Event Method
      private void PART_Btn_Play_Click(object sender, RoutedEventArgs e)
      {
         if (!this.VlcIsNotNull()) return;

         if (this.GetVlcMediaPlayer().State == MediaStates.Paused)
         {
            this.GetVlcMediaPlayer().Play();
         }
         else if (this.GetVlcMediaPlayer().State == MediaStates.Stopped || this.GetVlcMediaPlayer().State == MediaStates.NothingSpecial)
         {
            //this.PART_VlcControl.SourceProvider.MediaPlayer.Play(new FileInfo(@"D:\迅雷下载\复仇者联盟4：终局之战.mp4"));
         }
      }

      private void PART_Btn_Pause_Click(object sender, RoutedEventArgs e)
      {
         this.PART_VlcControl.SourceProvider.MediaPlayer.Pause();
      }

      private void PART_Btn_Stop_Click(object sender, RoutedEventArgs e)
      {
         Task.Run(() =>
         {
            this.PART_VlcControl.SourceProvider.MediaPlayer.Stop();
         });
      }
      /// <summary>
      /// 视频播放
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PART_Btn_PlayLocalFile_Click(object sender, RoutedEventArgs e)
      {
         try
         {
            if (IsPlaying)
            {
               GetVlcMediaPlayer().Stop();
            }
            PART_PlayInfo.Visibility = Visibility.Collapsed;
            FileInfo fileInfo = new FileInfo(PART_Txt_VideoSource.Text);
            if (fileInfo.Exists)
            {
               this.Play(fileInfo);
            }
         }
         catch (Exception)
         {
         }
      }

      private void PART_Btn_PlayUri_Click(object sender, RoutedEventArgs e)
      {
         PART_PlayInfo.Visibility = Visibility.Collapsed;
         if (IsPlaying)
         {
            GetVlcMediaPlayer().Stop();
         }
         this.Play(new Uri(PART_Txt_VideoSource.Text));
      }

      private void PART_Btn_Next_Click(object sender, RoutedEventArgs e)
      {

      }

      private void PART_Btn_Previous_Click(object sender, RoutedEventArgs e)
      {

      }

      private void MediaPlayer_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
      {
         this.VideoIsPlaying();

      }

      private void MediaPlayer_Paused(object sender, Vlc.DotNet.Core.VlcMediaPlayerPausedEventArgs e)
      {
         this.VideoPaused();
      }

      private void MediaPlayer_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
      {
         this.VideoStoped();
      }

      private void MediaPlayer_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
      {
         this.SetVideoCurrentTime(e.NewPosition * this._videoLength);
      }

      private void MediaPlayer_LengthChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs e)
      {
         this._videoLength = e.NewLength;
         this.SetVideoTotalTime(e.NewLength);
      }

      private void VideoPlayer_SnapshotTaken(object sender, VlcMediaPlayerSnapshotTakenEventArgs e)
      {
         VlcUtil.ScreenshotWithWatermark(e.FileName, "127.0.0.1", Brushes.White, 3, 2);
      }

      private void PART_Slider_DropValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         //if (this.VlcIsNotNull())
         //{
         //    this.GetVlcMediaPlayer().Pause();
         //}
         this.SetVideoCurrentTime(e.NewValue, true);
      }

      private void PART_MouseOver_Area_MouseEnter(object sender, MouseEventArgs e)
      {
         if (IsPlaying)
         {
            _isOverBottomTool = true;
            VisualStateManager.GoToState(this, "ShowVideoTool", true);
         }
      }

      private void PART_MouseOver_Area_MouseLeave(object sender, MouseEventArgs e)
      {
         if (IsPlaying)
         {
            _isOverBottomTool = false;
            Task.Delay(1000).ContinueWith((t) =>
            {
               Application.Current.Dispatcher.Invoke(() =>
                   {
                   if (!this._isOverBottomTool)
                   {
                      VisualStateManager.GoToState(this, "HideVideoTool", true);
                   }
                });
            });
         }
      }
      #endregion

      #region private methods
      private bool VlcIsNotNull()
      {
         return this.PART_VlcControl != null && this.PART_VlcControl.SourceProvider.MediaPlayer != null;
      }

      private VlcMediaPlayer GetVlcMediaPlayer()
      {
         return this.PART_VlcControl.SourceProvider.MediaPlayer;
      }

      private void SetVideoTotalTime(long newLength)
      {
         if (this.PART_Time_Total != null)
         {
            Application.Current.Dispatcher.Invoke(() =>
            {
               this.PART_Time_Total.Text = TimeSpan.FromMilliseconds(newLength).ToString("hh\\:mm\\:ss");
            });
         }
         if (this.PART_Slider != null)
         {
            Application.Current.Dispatcher.Invoke(() =>
            {
               this.PART_Slider.Maximum = newLength;
            });
         }
      }

      private void SetVideoCurrentTime(double newPosition, bool isMoveToPoint = false)
      {
         this._currentPosition = (long)newPosition;
         if (this.PART_Time_Current != null)
         {
            Application.Current.Dispatcher.Invoke(() =>
            {
               this.PART_Time_Current.Text = TimeSpan.FromMilliseconds(newPosition).ToString("hh\\:mm\\:ss");
            });
         }
         if (this.PART_Slider != null)
         {
            Application.Current.Dispatcher.Invoke(() =>
            {
               this.PART_Slider.Value = newPosition;
            });
         }
         if (this.VlcIsNotNull() && isMoveToPoint)
         {
            Application.Current.Dispatcher.Invoke(() =>
            {
               this.GetVlcMediaPlayer().Time = (long)newPosition;
            });
         }
      }

      private void VideoIsPlaying()
      {
         Application.Current.Dispatcher.Invoke(() =>
         {
            this.IsPlaying = true;
            this.PART_Loading.IsActived = false;
            this.PART_Loading.Visibility = Visibility.Collapsed;
            this.PART_Btn_Play.Visibility = Visibility.Collapsed;
            this.PART_Btn_Pause.Visibility = Visibility.Visible;
            this.PART_Video_Time.Visibility = Visibility.Visible;
            this.PART_Btn_Slower.Visibility = Visibility.Visible;
            this.PART_Btn_Faster.Visibility = Visibility.Visible;
            this.PART_Slider.Visibility = Visibility.Visible;
            this.PART_Btn_Screenshot.Visibility = Visibility.Visible;

            this.PART_Btn_Stop.IsEnabled = true;
            this.PART_Btn_Next.IsEnabled = true;
            this.PART_Btn_Previous.IsEnabled = true;

            VisualStateManager.GoToState(this, "HideVideoTool", true);
         });
      }

      private void VideoPaused()
      {
         Application.Current.Dispatcher.Invoke(() =>
         {
            this.PART_Loading.IsActived = true;
            this.PART_Loading.Visibility = Visibility.Visible;
            this.PART_Btn_Play.Visibility = Visibility.Visible;
            this.PART_Btn_Pause.Visibility = Visibility.Collapsed;
         });
      }

      /// <summary>
      /// 视频停止时设置相应控件属性
      /// </summary>
      private void VideoStoped()
      {
         Application.Current.Dispatcher.Invoke(() =>
         {
            this.IsPlaying = false;

            this.PART_Btn_Play.Visibility = Visibility.Visible;
            this.PART_Btn_Pause.Visibility = Visibility.Collapsed;
            this.PART_Video_Time.Visibility = Visibility.Collapsed;
            this.PART_Btn_Slower.Visibility = Visibility.Collapsed;
            this.PART_Btn_Faster.Visibility = Visibility.Collapsed;
            this.PART_Slider.Visibility = Visibility.Collapsed;
            this.PART_Btn_Screenshot.Visibility = Visibility.Visible;

            this.PART_Btn_Stop.IsEnabled = false;
            this.PART_Btn_Next.IsEnabled = false;
            this.PART_Btn_Previous.IsEnabled = false;

            VisualStateManager.GoToState(this, "ShowVideoTool", true);
         });
      }

      /// <summary>
      /// 视频是否停止
      /// </summary>
      /// <returns></returns>
      private bool IsVideoStoped()
      {
         if (this.VlcIsNotNull())
         {
            return this.GetVlcMediaPlayer().State == MediaStates.Stopped;
         }
         return true;
      }
      #endregion

      #region public methods
      public void Play()
      {
         this.PART_Btn_Play_Click(this, new RoutedEventArgs());
      }

      /// <summary>
      /// 播放本地视频
      /// </summary>
      /// <param name="file"></param>
      /// <param name="options"></param>
      public void Play(FileInfo file, params string[] options)
      {
         if (this.VlcIsNotNull())
         {
            this.GetVlcMediaPlayer().Play(file, options);
         }
      }

      public void Play(Stream stream, params string[] options)
      {
         if (this.VlcIsNotNull())
         {
            this.GetVlcMediaPlayer().Play(stream, options);
         }
      }

      public void Play(string mrl, params string[] options)
      {
         if (this.VlcIsNotNull())
         {
            this.GetVlcMediaPlayer().Play(mrl, options);
         }
      }

      public void Play(Uri uri, params string[] options)
      {
         if (this.VlcIsNotNull())
         {
            this.GetVlcMediaPlayer().Play(uri, options);
         }
      }

      public void Stop()
      {
         this.PART_Btn_Stop_Click(this, new RoutedEventArgs());
      }

      public void Pause()
      {
         this.PART_Btn_Pause_Click(this, new RoutedEventArgs());
      }
      #endregion
   }
}
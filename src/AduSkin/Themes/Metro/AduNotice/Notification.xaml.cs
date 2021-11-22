using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace AduSkin.Controls.Metro
{
    /// <summary>
    /// Notification.xaml 的交互逻辑
    /// </summary>
    public partial class Notification : Window
    {
        private const byte MAX_NOTIFICATIONS = 8;
        private int count;
        private readonly ObservableCollection<NotificationModel> buffer = new ObservableCollection<NotificationModel>();
        private ObservableCollection<NotificationModel> NotificationList = new ObservableCollection<NotificationModel>();
        private const double topOffset = 40;
        private const double leftOffset = 350;

        public Notification()
        {
            InitializeComponent();

            this.NotificationsControl.DataContext = this.NotificationList;
            this.Top = SystemParameters.WorkArea.Top + topOffset;
            this.Left = SystemParameters.WorkArea.Left + SystemParameters.WorkArea.Width - this.Width;
            this.Height = SystemParameters.WorkArea.Height; 
        }

        public void AddNotification(NotificationModel notification)
        {
            notification.Id = count++;
            if (NotificationList.Count + 1 > MAX_NOTIFICATIONS)
                buffer.Add(notification);
            else
                NotificationList.Add(notification);

            //Show window if there're notifications
            if (NotificationList.Count > 0 && !IsActive)
                Show();
        }

        public void RemoveNotification(NotificationModel notification)
        {
            if (NotificationList.Contains(notification))
                NotificationList.Remove(notification);

            if (buffer.Count > 0)
            {
                NotificationList.Add(buffer[0]);
                buffer.RemoveAt(0);
            }

            //Close window if there's nothing to show
            if (NotificationList.Count < 1)
                Hide();
        }

        private void NoticeGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height != 0.0)
                return;
            var element = sender as Grid;
            RemoveNotification(NotificationList.First(n => n.Id == Int32.Parse(element.Tag.ToString())));
        }
    }

    public class NotificationModel
    {
        /// <summary>
        /// Id不需要赋值
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 通知标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 通知内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 通知类型
        /// </summary>
        public EnumPromptType NotificationType { get; set; }
    }

   public class NoticeManager
   {
      public static Notification NotificationShow { get;set;}

      public static void Initialize() 
      {
         NotificationShow = new Notification();
      }
      public static void ExitNotification()
      {
         NotificationShow?.Close();
      }
   }
}

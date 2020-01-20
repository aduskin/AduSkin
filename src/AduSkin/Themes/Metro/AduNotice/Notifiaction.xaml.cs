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
    /// Notifiaction.xaml 的交互逻辑
    /// </summary>
    public partial class Notifiaction : Window
    {
        private const byte MAX_NOTIFICATIONS = 8;
        private int count;
        private readonly ObservableCollection<NotifiactionModel> buffer = new ObservableCollection<NotifiactionModel>();
        private ObservableCollection<NotifiactionModel> NotifiactionList = new ObservableCollection<NotifiactionModel>();
        private const double topOffset = 40;
        private const double leftOffset = 350;

        public Notifiaction()
        {
            InitializeComponent();

            this.NotificationsControl.DataContext = this.NotifiactionList;
            this.Top = SystemParameters.WorkArea.Top + topOffset;
            this.Left = SystemParameters.WorkArea.Left + SystemParameters.WorkArea.Width - this.Width;
            this.Height = SystemParameters.WorkArea.Height; 
        }

        public void AddNotifiaction(NotifiactionModel notification)
        {
            notification.Id = count++;
            if (NotifiactionList.Count + 1 > MAX_NOTIFICATIONS)
                buffer.Add(notification);
            else
                NotifiactionList.Add(notification);

            //Show window if there're notifications
            if (NotifiactionList.Count > 0 && !IsActive)
                Show();
        }

        public void RemoveNotification(NotifiactionModel notification)
        {
            if (NotifiactionList.Contains(notification))
                NotifiactionList.Remove(notification);

            if (buffer.Count > 0)
            {
                NotifiactionList.Add(buffer[0]);
                buffer.RemoveAt(0);
            }

            //Close window if there's nothing to show
            if (NotifiactionList.Count < 1)
                Hide();
        }

        private void NoticeGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height != 0.0)
                return;
            var element = sender as Grid;
            RemoveNotification(NotifiactionList.First(n => n.Id == Int32.Parse(element.Tag.ToString())));
        }
    }

    public class NotifiactionModel
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
        public EnumPromptType NotifiactionType { get; set; }
    }

   public class NoticeManager
   {
      public static Notifiaction NotifiactionShow { get;set;}

      public static void Initialize() 
      {
         NotifiactionShow = new Notifiaction();
      }
      public static void ExitNotifiaction()
      {
         NotifiactionShow?.Close();
      }
   }
}

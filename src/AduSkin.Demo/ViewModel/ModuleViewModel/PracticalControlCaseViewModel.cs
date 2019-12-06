using AduSkin.Controls;
using AduSkin.Controls.Metro.AduNotice;
using AduSkin.Demo.Models;
using AduSkin.Demo.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AduSkin.Demo.ViewModel
{
   public class PracticalControlCaseViewModel: ViewModelBase
   {
      /// <summary>
      /// 命令Command
      /// </summary>
      public ICommand OpenDemo => new RelayCommand<string>((e) =>
      {
         switch (e)
         {
            case "About":
               new AduSkinDemo().Show();
               return;
            case "Video":
               new AduVideoDemo().Show();
               return;
            default:
               break;
         }
      });

      #region 弹框
      private ObservableCollection<NoticeInfo> _NoticeList;

      public ObservableCollection<NoticeInfo> NoticeList
      {
         get
         {
            if (_NoticeList == null)
            {
               _NoticeList = new ObservableCollection<NoticeInfo>();
            }
            return _NoticeList;
         }
         set { _NoticeList = value; }
      }
      private Notifiaction _NotifiactionWin;
      public Notifiaction NotifiactionWin
      {
         get
         {
            if (_NotifiactionWin == null)
            {
               _NotifiactionWin = new Notifiaction();
            }
            return _NotifiactionWin;
         }
      }



      /// <summary>
      /// 命令Command
      /// </summary>
      public ICommand OpenMsg => new RelayCommand<string>((e) =>
      {
         switch (e)
         {
            case "Error":
               NotifiactionWin.AddNotifiaction(new NotifiactionModel()
               {
                  Title = "这是Error通知标题",
                  Content = "这条通知不会自动关闭，需要点击关闭按钮",
                  NotifiactionType = EnumPromptType.Error
               });
               return;
            case "Success":
               NotifiactionWin.AddNotifiaction(new NotifiactionModel()
               {
                  Title = "这是Success通知标题",
                  Content = "这条通知不会自动关闭，需要点击关闭按钮这条通知不会自动关闭，需要点击关闭按钮这条通知不会自动关闭，需要点击关闭按钮",
                  NotifiactionType = EnumPromptType.Success
               });
               return;
            case "Warm":
               NotifiactionWin.AddNotifiaction(new NotifiactionModel()
               {
                  Title = "这是Warn通知标题",
                  Content = "这条通知不会自动关闭，需要点击关闭按钮",
                  NotifiactionType = EnumPromptType.Warn
               });
               return;
            case "Info":
               NotifiactionWin.AddNotifiaction(new NotifiactionModel()
               {
                  Title = "这是Info通知标题",
                  Content = "这条通知不会自动关闭"
               });
               return;
            default:
               break;
         }
      });
      #endregion
   }
}

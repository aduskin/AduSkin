using AduSkin.Controls;
using AduSkin.Controls.Metro;
using AduSkin.Demo.Models;
using AduSkin.Utility;
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
   public class HttpToolViewModel : ViewModelBase
   {
      public HttpToolViewModel()
      {
         //请求编码类型
         CodeTypeList = new ObservableCollection<Sys_Code>
            {
                new Sys_Code{CodeValue="utf8",CodeName="utf-8"}
                , new Sys_Code{CodeValue="utf7",CodeName="utf-7"}
                , new Sys_Code{CodeValue="utf32",CodeName="utf-32"}
                , new Sys_Code{CodeValue="ascii",CodeName="ascii"}
                , new Sys_Code{CodeValue="unicode",CodeName="unicode"}
            };
         CurrentCodeType = CodeTypeList[0];
         //请求类型
         HttpTypList = new ObservableCollection<Sys_Code>
            {
                new Sys_Code{CodeValue="get",CodeName="get"}
                , new Sys_Code{CodeValue="post",CodeName="post"}
                , new Sys_Code{CodeValue="put",CodeName="put"}
                , new Sys_Code{CodeValue="delete",CodeName="delete"}
            };
         CurrentHttpType = HttpTypList[0];

         //请求参数默认两个空
         RequestParameter = new ObservableCollection<Sys_Code>
            {
                new Sys_Code("","")
                , new Sys_Code("","")
            };
         //请求头默认两个空
         RequestHead = new ObservableCollection<Sys_Code>
            {
                new Sys_Code("","")
                , new Sys_Code("","")
            };
      }

      #region 页面数据
      private ObservableCollection<Sys_Code> _HttpTypList;
      /// <summary>
      /// 请求方式
      /// </summary>
      public ObservableCollection<Sys_Code> HttpTypList
      {
         get { return _HttpTypList; }
         set { Set(ref _HttpTypList, value); }
      }


      private Sys_Code _CurrentHttpType;
      /// <summary>
      /// 当前请求方式
      /// </summary>
      public Sys_Code CurrentHttpType
      {
         get { return _CurrentHttpType; }
         set { Set(ref _CurrentHttpType, value); }
      }

      private ObservableCollection<Sys_Code> _CodeTypeList;
      /// <summary>
      /// 编码类型
      /// </summary>
      public ObservableCollection<Sys_Code> CodeTypeList
      {
         get { return _CodeTypeList; }
         set { Set(ref _CodeTypeList, value); }
      }

      private Sys_Code _CurrentCodeType;
      /// <summary>
      /// 当前请求编码类型
      /// </summary>
      public Sys_Code CurrentCodeType
      {
         get { return _CurrentCodeType; }
         set { Set(ref _CurrentCodeType, value); }
      }

      private ObservableCollection<Sys_Code> _RequestParameter;
      /// <summary>
      /// 属性.
      /// </summary>
      public ObservableCollection<Sys_Code> RequestParameter
      {
         get { return _RequestParameter; }
         set { Set(ref _RequestParameter, value); }
      }


      private ObservableCollection<Sys_Code> _RequestHead;
      /// <summary>
      /// 属性.
      /// </summary>
      public ObservableCollection<Sys_Code> RequestHead
      {
         get { return _RequestHead; }
         set { Set(ref _RequestHead, value); }
      }

      private string _ToUrlTxt;
      /// <summary>
      /// 属性.
      /// </summary>
      public string ToUrlTxt
      {
         get { return _ToUrlTxt; }
         set { Set(ref _ToUrlTxt, value); }
      }
      #endregion

      #region 命令
      /// <summary>
      /// 添加请求参数
      /// </summary>
      public ICommand AddRequestCodeCommand => new RelayCommand<string>((e) =>
      {
         if (e == "Param")
            RequestParameter.Add(new Sys_Code("", ""));
         else
            RequestHead.Add(new Sys_Code());
      });

      /// <summary>
      /// 删除当前参数
      /// </summary>    
      public ICommand RemoveParameter => new RelayCommand<Sys_Code>((e) =>
      {
         RequestParameter.Remove(e);
      });

      /// <summary>
      /// 删除请求头
      /// </summary>    
      public ICommand RemoveHeader => new RelayCommand<Sys_Code>((e) =>
      {
         RequestHead.Remove(e);
      });

      #region 请求方法
      public TaskFactory _task = new TaskFactory();
      public WebList Result = null;
      /// <summary>
      /// 开始请求
      /// </summary>
      public ICommand ToRequest => new RelayCommand(() =>
      {
         if (!string.IsNullOrEmpty(ToUrlTxt))
         {
            if (!ToUrlTxt.StartsWith("http"))
            {
               ToUrlTxt = "http://" + ToUrlTxt;
            }
            //请求方式，编码
            string RequestMethod = CurrentHttpType.CodeValue;
            string RequestEnCode = CurrentCodeType.CodeValue;
            string RequestUrl = ToUrlTxt;
            List<TItem> Parameters = new List<TItem>();
            List<TItem> Headers = new List<TItem>();
            //请求参数
            foreach (Sys_Code item in RequestParameter)
            {
               if (!string.IsNullOrEmpty(item.CodeName) && !string.IsNullOrEmpty(item.CodeValue))
               {
                  Parameters.Add(new TItem()
                  {
                     Name = item.CodeName,
                     Value = item.CodeValue
                  });
               }
            }
            foreach (Sys_Code item in RequestHead)
            {
               if (!string.IsNullOrEmpty(item.CodeName) && !string.IsNullOrEmpty(item.CodeValue))
               {
                  Headers.Add(new TItem()
                  {
                     Name = item.CodeName,
                     Value = item.CodeValue
                  });
               }
            }
            //Action task = () =>
            //{
               if (CurrentHttpType.CodeValue.ToUpper() == "GET")
                  Result = HttpHelper.Http_Get(RequestUrl, Headers, Parameters, (Encode)Enum.Parse(typeof(Encode), RequestEnCode.ToUpper()));
               else
                  Result = HttpHelper.Http_Post(RequestUrl, Headers, Parameters, (Encode)Enum.Parse(typeof(Encode), RequestEnCode.ToUpper()));
            //};
            //Task[] tasks = new Task[] { _task.StartNew(task) };
            //_task.ContinueWhenAll(tasks, (action => { ShowResult(); }));
            ShowResult();
         }
      });

      public void ShowResult()
      {
         if (Result != null)
            NoticeManager.NotificationShow.AddNotification(new NotificationModel()
            {
               Title = Result.AbsoluteUri,
               Content = Result.ToStringX().ToString(),
               NotificationType = EnumPromptType.Success
            });
         else
            NoticeManager.NotificationShow.AddNotification(new NotificationModel()
            {
               Title = "请求失败！",
               Content = "未请求到任何数据",
               NotificationType = EnumPromptType.Error
            });
      }

      #endregion

      #endregion
   }
}

using AduSkin.Demo.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AduSkin.Demo.ViewModel
{
  public class HttpToolViewModel : ViewModelBase
   {
      public HttpToolViewModel()
      {
         //请求编码类型
         CodeTypeList = new ObservableCollection<Sys_Code>
            {
                new Sys_Code{CodeValue="utf-8",CodeName="utf-8"}
                , new Sys_Code{CodeValue="utf-7",CodeName="utf-7"}
                , new Sys_Code{CodeValue="utf-32",CodeName="utf-32"}
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
      }

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
   }
}

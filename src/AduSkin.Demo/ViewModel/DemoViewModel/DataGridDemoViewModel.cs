using AduSkin.Demo.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AduSkin.Demo.ViewModel.DemoViewModel
{
   public class DataGridDemoViewModel:ViewModelBase
   {
      public DataGridDemoViewModel()
      {
         var tempContactList = new List<ChatUserModel>();
         ChatUserModel group = new ChatUserModel();
         group.UserName = "Flutter开发组";
         group.Header = "pack://application:,,,/Resources/Img/Header/头像1.png";
         group.Describe = "寻找适合你的UI";
         tempContactList.Add(group);

         ChatUserModel Group1 = new ChatUserModel();
         Group1.UserName = "AduSkin开发组";
         Group1.Header = "pack://application:,,,/Resources/Img/Header/头像2.png";
         Group1.Describe = "开发者论坛";
         tempContactList.Add(Group1);

         ChatUserModel item = new ChatUserModel();
         item.UserName = "AduSkin";
         item.Header = "pack://application:,,,/Resources/Img/Header/头像3.png";
         item.Describe = "追求极致，永臻完美";
         tempContactList.Add(item);

         ChatUserModel item1 = new ChatUserModel();
         item1.UserName = "千百度";
         item1.Header = "pack://application:,,,/Resources/Img/Header/头像4.png";
         item1.Describe = "追求极致，永臻完美";
         tempContactList.Add(item1);

         ChatUserModel item2 = new ChatUserModel();
         item2.UserName = "万里独行";
         item2.Header = "pack://application:,,,/Resources/Img/Header/头像5.png";
         item2.Describe = "追求极致，永臻完美";
         tempContactList.Add(item2);

         ChatUserModel item3 = new ChatUserModel();
         item3.UserName = "一个人";
         item3.Header = "pack://application:,,,/Resources/Img/Header/头像6.png";
         item3.Describe = "追求极致，永臻完美";
         tempContactList.Add(item3);

         ChatUserModel item4 = new ChatUserModel();
         item4.UserName = "AduMusic";
         item4.Header = "pack://application:,,,/Resources/Img/Header/头像1.png";
         item4.Describe = "追求极致，永臻完美";
         tempContactList.Add(item4);

         ChatUserModel item6 = new ChatUserModel();
         item6.UserName = "往事如风";
         item6.Header = "pack://application:,,,/Resources/Img/Header/头像2.png";
         item6.Describe = "美滋滋";
         tempContactList.Add(item6);

         ChatUserModel item7 = new ChatUserModel();
         item7.UserName = "美滋滋";
         item7.Header = "pack://application:,,,/Resources/Img/Header/头像3.png";
         item7.Describe = "不需要太多";
         tempContactList.Add(item7);

         contactList =new ObservableCollection<ChatUserModel>(tempContactList);
      }

      private ObservableCollection<ChatUserModel> contactList;
      /// <summary>
      /// 联系人列表
      /// </summary>
      public ObservableCollection<ChatUserModel> ContactList
      {
         get
         {
            return contactList;
         }
      }


      private bool _IsAllChecked;
      /// <summary>
      /// 全选
      /// </summary>
      public bool IsAllChecked
      {
         get { return _IsAllChecked; }
         set
         {
            Set(ref _IsAllChecked, value);
            foreach (var item in ContactList)
            {
               item.IsChecked = value;
            }
         }
      }

   }
}

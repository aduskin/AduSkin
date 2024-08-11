using AduSkin.Controls;
using AduSkin.Demo.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AduSkin.Demo.ViewModel
{
   public class SortGroupViewModel : ObservableObject
   {
      public SortGroupViewModel()
      {
         var tempContactList = new List<ChatUserModel>();
         ChatUserModel group = new ChatUserModel();
         group.ContactType = ContactType.Group;
         group.UserName = "Flutter开发组";
         group.Header = "pack://application:,,,/Resources/Img/Header/头像1.png";
         group.Describe = "寻找适合你的UI";
         tempContactList.Add(group);

         ChatUserModel Group1 = new ChatUserModel();
         Group1.ContactType = ContactType.Group;
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

         contactList = Sort(tempContactList);
      }

      /// <summary>
      /// 排序
      /// </summary>
      /// <param name="Temps"></param>
      /// <returns></returns>
      public List<ChatUserModel> Sort(List<ChatUserModel> Temps)
      {
         List<ChatUserModel> ResultList = new List<ChatUserModel>();
         Dictionary<string, List<ChatUserModel>> dic = new Dictionary<string, List<ChatUserModel>>();
         List<string> sorts = new List<string>() { "群组", "A", "B", "C", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "#" };
         foreach (var item in sorts)
            dic.Add(item, new List<ChatUserModel>());
         //将对象按字母顺序存起来
         for (int i = 0; i < Temps.Count; i++)
         {
            //群组
            if (Temps[i].ContactType == ContactType.Group)
            {
               dic["群组"].Add(Temps[i]);
               continue;
            }
            //个人
            var subhead = AduSkin.Utility.Extend.StringExtend.GetFirstPinyin(Temps[i].UserName);
            Temps[i].SortID = subhead;
            if (dic.ContainsKey(subhead))
               dic[subhead].Add(Temps[i]);
         }
         //先把群组存入列表
         var groupsort = new ChatUserModel() { SortID = "群组", ContactType = ContactType.SerialNumber };
         ResultList.Add(groupsort);
         foreach (var item in dic["群组"])
         {
            ResultList.Add(item);
         }

         foreach (var item in dic)
         {
            if (item.Value.Count <= 0 || item.Key == "群组")
            {
               continue;
            }
            var sortid = new ChatUserModel() { SortID = item.Key, ContactType = ContactType.SerialNumber };
            if (!ResultList.Contains(sortid))
            {
               ResultList.Add(sortid);
            }
            foreach (var chatuser in item.Value)
            {
               chatuser.ContactType = ContactType.Single;
               ResultList.Add(chatuser);
            }
         }
         return ResultList;
      }

      private List<ChatUserModel> contactList;
      /// <summary>
      /// 联系人列表
      /// </summary>
      public ObservableCollection<ChatUserModel> ContactList
      {
         get
         {
            return new ObservableCollection<ChatUserModel>(contactList);
         }
      }
      /// <summary>
      /// 序号列表
      /// </summary>
      public ObservableCollection<ChatUserModel> SortID
      {
         get
         {
            return new ObservableCollection<ChatUserModel>(contactList.Where(a => a.ContactType == ContactType.SerialNumber));
         }
      }

      private ChatUserModel _CurrentChatUserModel;
      /// <summary>
      /// 当前选中的用户/群组/序号
      /// </summary>
      public ChatUserModel CurrentChatUserModel
      {
         get { return _CurrentChatUserModel; }
         set
         {
            if (value.ContactType == ContactType.SerialNumber)
            {
               IsOpenSortList = true;
            }
            SetProperty(ref _CurrentChatUserModel, value);
         }
      }

      private bool _IsOpenSortList = false;
      /// <summary>
      /// 显示序号
      /// </summary>
      public bool IsOpenSortList
      {
         get { return _IsOpenSortList; }
         set { SetProperty(ref _IsOpenSortList, value); }
      }
   }
}

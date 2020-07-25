using AduSkin.Demo.Data.Enum;
using AduSkin.Demo.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AduSkin.Demo.ViewModel
{
   public class AduSkinSupportViewModel : ViewModelBase
   {
      public AduSkinSupportViewModel()
      {
         AllSupports.Add(new SupportUser("不愿意透露姓名的网友", "tencent://message/?uin=870856195&Site=&Menu=yes", "http://q.qlogo.cn/headimg_dl?bs=qq&dst_uin=870856195&spec=100","",new string[] { SupportType.Money.ToString()+"：100元" }));
         AllSupports.Add(new SupportUser("沙漠尽头的狼 dotnet9.com", "tencent://message/?uin=632871194&Site=&Menu=yes", "http://q.qlogo.cn/headimg_dl?bs=qq&dst_uin=632871194&spec=100", "", new string[] { SupportType.Skill.ToString(), SupportType.Extension.ToString() }));
         AllSupports.Add(new SupportUser("关关", "tencent://message/?uin=2453966523&Site=&Menu=yes", "http://q.qlogo.cn/headimg_dl?bs=qq&dst_uin=2453966523&spec=100", "", new string[] { SupportType.Skill.ToString(), SupportType.Extension.ToString() }));
         AllSupports.Add(new SupportUser("Tom", "tencent://message/?uin=17379620&Site=&Menu=yes", "http://q.qlogo.cn/headimg_dl?bs=qq&dst_uin=17379620&spec=100", "", new string[] { SupportType.Skill.ToString(), SupportType.Extension.ToString(),SupportType.Money.ToString() + "：350元" }));
         AllSupports.Add(new SupportUser("KING", "tencent://message/?uin=1061973727&Site=&Menu=yes", "http://q.qlogo.cn/headimg_dl?bs=qq&dst_uin=1061973727&spec=100", "", new string[] { SupportType.Skill.ToString()}));
         AllSupports.Add(new SupportUser("FOX-Yu", "", "http://q.qlogo.cn/headimg_dl?bs=qq&dst_uin=435892115&spec=100", "", new string[] { SupportType.Money.ToString() + "：88元" }));
         AllSupports.Add(new SupportUser("不愿意透露姓名的网友", "", "http://q.qlogo.cn/headimg_dl?bs=qq&dst_uin=2603473237&spec=100", "", new string[] { SupportType.Money.ToString() + "：300元" }));
      }
      private ObservableCollection<SupportUser> _AllSupports =new ObservableCollection<SupportUser>();
      /// <summary>
      /// 赞助人
      /// </summary>
      public ObservableCollection<SupportUser> AllSupports
      {
         get { return _AllSupports; }
         set { Set(ref _AllSupports, value); }
      }

      /// <summary>
      /// 命令Command
      /// </summary>
      public ICommand OpenDemo => new RelayCommand<string>((e) =>
      {
         switch (e)
         {
            case "Reward":
               IsOpenReward = true;
               return;
            default:
               break;
         }
      });

      private bool _IsOpenReward;
      /// <summary>
      /// 属性.
      /// </summary>
      public bool IsOpenReward
      {
         get { return _IsOpenReward; }
         set { Set(ref _IsOpenReward, value); }
      }
   }
}

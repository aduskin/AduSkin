using AduSkin.Demo.Data;
using AduSkin.Demo.Models;
using AduSkin.Demo.UserControls;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AduSkin.Demo.ViewModel
{
   public class MainViewModel : ViewModelBase
   {

      public MainViewModel()
      {
         _AllControl = new List<ControlModel>()
         {
            new ControlModel("Win10菜单", typeof(SortGroup)),
            new ControlModel("图片上传", typeof(UploadPic)),
            new ControlModel("视频控件", typeof(VideoPlayer)),
            new ControlModel("折叠菜单", typeof(ExpanderMenu)),
            new ControlModel("导航容器", typeof(NavigationPanel)),
            new ControlModel("轮播容器", typeof(CarouselContainer)),
            new ControlModel("时间轴", typeof(TimeLine)),
            new ControlModel("树形菜单", typeof(TreeMenu)),
            new ControlModel("数据列表", typeof(DataGridDemo)),
         };
         _SearchControl = _AllControl;
      }

      private List<ControlModel> _AllControl;
      /// <summary>
      /// 所有控件
      /// </summary>
      public List<ControlModel> AllControl
      {
         get { return _AllControl; }
         set { Set(ref _AllControl, value); }
      }

      private List<ControlModel> _SearchControl;
      /// <summary>
      /// 所有控件
      /// </summary>
      public List<ControlModel> SearchControl
      {
         get { return _SearchControl; }
         set {
            Set(ref _SearchControl, value);
         }
      }

      private ControlModel _CurrentShowControl;
      /// <summary>
      /// 当前显示控件
      /// </summary>
      public ControlModel CurrentShowControl
      {
         get { return _CurrentShowControl; }
         set { Set(ref _CurrentShowControl, value); }
      }

      private UserControl _content = new SortGroup();
      public UserControl Content
      {
         get { return _content; }
         set { Set(ref _content, value); }
      }

      private string _Title = "Win10菜单";
      public string Title
      {
         get { return _Title; }
         set { Set(ref _Title, value); }
      }

      private string _SearchKey;
      public string SearchKey
      {
         get { return _SearchKey; }
         set
         {

            Set(ref _SearchKey, value);
            OnSearchKeyChanged();
         }
      }

      private void OnSearchKeyChanged()
      {
         if (string.IsNullOrWhiteSpace(SearchKey))
         {
            SearchControl = _AllControl;
            return;
         }
         SearchControl = _AllControl.Where(a => a.Title.ToLowerInvariant().Contains(SearchKey.ToLowerInvariant()) || a.Tags.ToLowerInvariant().Contains(SearchKey.ToLowerInvariant())).ToList();
      }
   }
}

using AduSkin.Demo.Data.Enum;
using AduSkin.Demo.Models;
using AduSkin.Demo.UserControls;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace AduSkin.Demo.ViewModel
{
   public class PracticalCaseViewModel: ViewModelBase
   {
      public PracticalCaseViewModel()
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
            new ControlModel("多功能Tab", typeof(MultiFunctionTabControl)),
            new ControlModel("右键菜单", typeof(ContextMenuDemo)),
            new ControlModel("右侧弹框", typeof(NoticeDemo)),
            new ControlModel("过渡容器", typeof(TransitioningContentControlDemo)),
            new ControlModel("接口调试工具", typeof(HttpTool),DemoType.Tool),
         };
         _SearchControl.Source= _AllControl;
         _SearchControl.View.Culture = new System.Globalization.CultureInfo("zh-CN");
         _SearchControl.View.Filter = (obj) => ((obj as ControlModel).Title+ (obj as ControlModel).TitlePinyin).ToLower().Contains(SearchKey.ToLower());
         _SearchControl.View.SortDescriptions.Add(new SortDescription(nameof(ControlModel.Title), ListSortDirection.Ascending));


         Content = (UserControl)Activator.CreateInstance(AllControl.First().Content);
         CurrentShowControl = _AllControl.First();
      }

      private IEnumerable<ControlModel> _AllControl;
      /// <summary>
      /// 所有控件
      /// </summary>
      public IEnumerable<ControlModel> AllControl
      {
         get { return _AllControl; }
         set { Set(ref _AllControl, value); }
      }

      private CollectionViewSource _SearchControl = new CollectionViewSource();
      /// <summary>
      /// 所有控件
      /// </summary>
      public CollectionViewSource SearchControl
      {
         get { return _SearchControl; }
         set
         {
            Set(ref _SearchControl, value);
         }
      }

      /// <summary>
      /// 显示代码案例栏
      /// </summary>
      public bool IsShowCode => CurrentShowControl.Type == DemoType.Demo;

      /// <summary>
      /// 属性.
      /// </summary>
      public double ShowCodeHeight
      {
         get 
         {
            if (CurrentShowControl.Type == DemoType.Demo)
               return 40;
            else
               return 0;
         }
      }

      private string _CurrentShowCode;
      /// <summary>
      /// 案例代码
      /// </summary>
      public string CurrentShowCode
      {
         get { return _CurrentShowCode; }
         set { Set(ref _CurrentShowCode, value); }
      }

      private ControlModel _CurrentShowControl;
      /// <summary>
      /// 当前显示控件
      /// </summary>
      public ControlModel CurrentShowControl
      {
         get { return _CurrentShowControl; }
         set {
            Set(ref _CurrentShowControl, value);
            RaisePropertyChanged("Content");
            RaisePropertyChanged("Title");
            RaisePropertyChanged("IsShowCode");
            RaisePropertyChanged("ShowCodeHeight");
         }
      }


      private int _ShowCodeTypeIndex = 0;
      /// <summary>
      /// 显示代码类型
      /// </summary>
      public int ShowCodeTypeIndex
      {
         get { return _ShowCodeTypeIndex; }
         set {
            if (value == 0)
               CurrentShowCode = CurrentShowControl.XAML;
            else
               CurrentShowCode = CurrentShowControl.Code;
            Set(ref _ShowCodeTypeIndex, value); 
         }
      }

      /// <summary>
      /// 控件显示
      /// </summary>
      private UserControl _content;
      public UserControl Content
      {
         get {
            if (CurrentShowControl == null)
               return null;
            return (UserControl)Activator.CreateInstance(CurrentShowControl.Content); 
         }
         set { Set(ref _content, value); }
      }
      /// <summary>
      /// 标题
      /// </summary>
      private string _Title = "Win10菜单";
      public string Title
      {
         get {
            if (CurrentShowControl == null)
               return null;
            return CurrentShowControl.Title; }
         set { Set(ref _Title, value); }
      }
      /// <summary>
      /// 搜索关键字
      /// </summary>
      private string _SearchKey="";
      public string SearchKey
      {
         get { return _SearchKey; }
         set
         {
            Set(ref _SearchKey, value);
            if (_SearchControl != null)
               _SearchControl.View.Refresh();
         }
      }
   }
}

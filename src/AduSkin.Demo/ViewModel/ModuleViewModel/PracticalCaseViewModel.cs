using AduSkin.Demo.Data.Enum;
using AduSkin.Demo.Models;
using AduSkin.Demo.UserControls;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace AduSkin.Demo.ViewModel
{
   public class PracticalCaseViewModel: ViewModelBase
   {
      public PracticalCaseViewModel()
      {
         #region 工具栏
         _AllTool = new List<ControlModel>()
         {
            //new ControlModel("百度翻译", typeof(BaiduTranslate),DemoType.Tool),
            new ControlModel("接口调试工具", typeof(HttpTool),DemoType.Tool),
         };
         _SearchTool.Source = _AllTool;
         _SearchTool.View.Culture = new System.Globalization.CultureInfo("zh-CN");
         _SearchTool.View.Filter = (obj) => ((obj as ControlModel).Title + (obj as ControlModel).TitlePinyin).ToLower().Contains(SearchKey.ToLower());
         _SearchTool.View.SortDescriptions.Add(new SortDescription(nameof(ControlModel.Title), ListSortDirection.Ascending));
         #endregion

         #region 实用控件
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
         };
         _SearchControl.Source= _AllControl;
         _SearchControl.View.Culture = new System.Globalization.CultureInfo("zh-CN");
         _SearchControl.View.Filter = (obj) => ((obj as ControlModel).Title+ (obj as ControlModel).TitlePinyin).ToLower().Contains(SearchKey.ToLower());
         _SearchControl.View.SortDescriptions.Add(new SortDescription(nameof(ControlModel.Title), ListSortDirection.Ascending));
         #endregion
      }

      private int _SelectedDemoType;
      /// <summary>
      /// 当前列表显示类型
      /// </summary>
      public int SelectedDemoType
      {
         get { return _SelectedDemoType; }
         set 
         {
            
            Set(ref _SelectedDemoType, value);
            if (value == 0)
               CurrentShowControl = _AllControl.First();
            else if (value == 1)
               CurrentShowTool = _AllTool.First();
            RaisePropertyChanged("IsShowCode");
            RaisePropertyChanged("SearchKey");
         }
      }

      #region 控件Demo
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
      #endregion

      #region 工具
      private IEnumerable<ControlModel> _AllTool;
      /// <summary>
      /// 所有控件
      /// </summary>
      public IEnumerable<ControlModel> AllTool
      {
         get { return _AllTool; }
         set { Set(ref _AllTool, value); }
      }

      private CollectionViewSource _SearchTool = new CollectionViewSource();
      /// <summary>
      /// 所有控件
      /// </summary>
      public CollectionViewSource SearchTool
      {
         get { return _SearchTool; }
         set
         {
            Set(ref _SearchTool, value);
         }
      }
      #endregion

      /// <summary>
      /// 显示代码案例栏
      /// </summary>
      public bool IsShowCode => CurrentShowControl?.Type == DemoType.Demo && SelectedDemoType == 0;

      /// <summary>
      /// 代码案例显示高度
      /// </summary>
      public double ShowCodeHeight
      {
         get 
         {
            if (CurrentShowControl?.Type == DemoType.Demo)
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

      private ControlModel _CurrentShowTool;
      /// <summary>
      /// 当前显示工具
      /// </summary>
      public ControlModel CurrentShowTool
      {
         get { return _CurrentShowTool; }
         set
         {
            Set(ref _CurrentShowTool, value);
            RaisePropertyChanged("Content");
            RaisePropertyChanged("Title");
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
            Set(ref _ShowCodeTypeIndex, value);
            if (value == 0)
               CurrentShowCode = CurrentShowControl.XAML;
            else
               CurrentShowCode = CurrentShowControl.Code;
         }
      }

      /// <summary>
      /// 控件显示
      /// </summary>
      private UserControl _content;
      public UserControl Content
      {
         get {

            if (SelectedDemoType == 0)
            {
               if (CurrentShowControl == null)
                  return null;
               return (UserControl)Activator.CreateInstance(CurrentShowControl.Content);
            }
            else
            {
               if (CurrentShowControl == null)
                  return null;
               return (UserControl)Activator.CreateInstance(CurrentShowTool.Content);
            }
               
         }
         set { 
            Set(ref _content, value);
         }
      }
      /// <summary>
      /// 标题
      /// </summary>
      private string _Title;
      public string Title
      {
         get {
            
            if (SelectedDemoType == 0)
            {
               if (CurrentShowControl == null)
                  return null;
               return CurrentShowControl.Title;
            }
            else
            {
               if (CurrentShowTool == null)
                  return null;
               return CurrentShowTool.Title;
            }
         }
         set { Set(ref _Title, value); }
      }
      /// <summary>
      /// 搜索关键字
      /// </summary>
      private string _SearchKey="";
      public string SearchKey
      {
         get {
            return _SearchKey; 
         }
         set
         {
            Set(ref _SearchKey, value);
            if (SelectedDemoType == 0)
               if (_SearchControl != null)
                  _SearchControl.View.Refresh();
            else if (SelectedDemoType == 1)
               if (_SearchTool != null)
                  _SearchTool.View.Refresh();
         }
      }
   }
}

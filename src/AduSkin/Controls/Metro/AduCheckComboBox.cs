using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using System.Linq;
using AduSkin.Controls.Helper;

namespace AduSkin.Controls.Metro
{
   public class AduCheckComboBox : ComboBox
   {
      #region PrivateProperty
      private ContentPresenter PART_ContentSite;
      private TextBox PART_FilterTextBox;
      private ICollectionView view;
      private Popup PART_Popup;

      private bool PopupIsFirstOpen;
      #endregion

      #region DependencyProperty
      public static readonly DependencyProperty ContentProperty =
          DependencyProperty.Register("Content", typeof(string), typeof(AduCheckComboBox), new PropertyMetadata(string.Empty));
      /// <summary>
      /// 内容
      /// </summary>
      public string Content
      {
         get { return (string)GetValue(ContentProperty); }
         set { SetValue(ContentProperty, value); }
      }

      public static readonly DependencyProperty ValueProperty =
          DependencyProperty.Register("Value", typeof(string), typeof(AduCheckComboBox), new PropertyMetadata(string.Empty));
      /// <summary>
      /// 值
      /// </summary>
      public string Value
      {
         get { return (string)GetValue(ValueProperty); }
         set { SetValue(ValueProperty, value); }
      }

      #region SelectedObjList
      [Bindable(true), Description("获取或者设置当前勾选项列表")]
      public ObservableCollection<object> SelectedObjList
      {
         get { return (ObservableCollection<object>)GetValue(SelectedObjListProperty); }
         set { SetValue(SelectedObjListProperty, value); }
      }

      public static readonly DependencyProperty SelectedObjListProperty =
          DependencyProperty.Register("SelectedObjList", typeof(ObservableCollection<object>), typeof(AduCheckComboBox), new PropertyMetadata(null, OnSelectedObjListChanged));

      private static void OnSelectedObjListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduCheckComboBox AduCheckComboBox = d as AduCheckComboBox;
         if (AduCheckComboBox.ItemsSource != null)
            AduCheckComboBox.SetAduCheckComboBoxValueAndContent();
      }
      #endregion

      #region SelectedStrList

      public ObservableCollection<string> SelectedStrList
      {
         get { return (ObservableCollection<string>)GetValue(SelectedStrListProperty); }
         set { SetValue(SelectedStrListProperty, value); }
      }

      public static readonly DependencyProperty SelectedStrListProperty =
          DependencyProperty.Register("SelectedStrList", typeof(ObservableCollection<string>), typeof(AduCheckComboBox));

      #endregion

      public static readonly DependencyProperty ToggleButtonColorProperty = DependencyProperty.Register("ToggleButtonColor"
            , typeof(Brush), typeof(AduCheckComboBox), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(238, 121, 111))));
      /// <summary>
      /// 下拉列表背景色
      /// </summary>
      public Brush ToggleButtonColor
      {
         get { return (Brush)GetValue(ToggleButtonColorProperty); }
         set { SetValue(ToggleButtonColorProperty, value); }
      }

      /// <summary>
      /// 获取或者设置下拉列表过滤文本框的显示与隐藏
      /// </summary>
      public bool IsShowFilterBox
      {
         get { return (bool)GetValue(IsShowFilterBoxProperty); }
         set { SetValue(IsShowFilterBoxProperty, value); }
      }

      public static readonly DependencyProperty IsShowFilterBoxProperty =
          DependencyProperty.Register("IsShowFilterBox", typeof(bool), typeof(AduCheckComboBox), new PropertyMetadata(false));

      /// <summary>
      /// 获取或者设置最多显示的选中个数
      /// </summary>
      public int MaxShowNumber
      {
         get { return (int)GetValue(MaxShowNumberProperty); }
         set { SetValue(MaxShowNumberProperty, value); }
      }

      public static readonly DependencyProperty MaxShowNumberProperty =
          DependencyProperty.Register("MaxShowNumber", typeof(int), typeof(AduCheckComboBox), new PropertyMetadata(4));

      public static readonly DependencyProperty InputHintProperty =
          DependencyProperty.Register("InputHint", typeof(string), typeof(AduCheckComboBox), new PropertyMetadata("请选择..."));
      public string InputHint
      {
         get { return (string)GetValue(InputHintProperty); }
         set { SetValue(InputHintProperty, value); }
      }

      public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius"
        , typeof(CornerRadius), typeof(AduCheckComboBox));
      /// <summary>
      /// 按钮四周圆角
      /// </summary>
      public CornerRadius CornerRadius
      {
         get { return (CornerRadius)GetValue(CornerRadiusProperty); }
         set { SetValue(CornerRadiusProperty, value); }
      }

      public static readonly DependencyProperty ComBoxItemPanelBackgroundProperty = DependencyProperty.Register("ComBoxItemPanelBackground"
            , typeof(Brush), typeof(AduCheckComboBox), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 255, 255))));
      /// <summary>
      /// 下拉列表背景色
      /// </summary>
      public Brush ComBoxItemPanelBackground
      {
         get { return (Brush)GetValue(ComBoxItemPanelBackgroundProperty); }
         set { SetValue(ComBoxItemPanelBackgroundProperty, value); }
      }

      #endregion

      #region Constructors
      static AduCheckComboBox()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduCheckComboBox), new FrameworkPropertyMetadata(typeof(AduCheckComboBox)));
      }
      public AduCheckComboBox()
      {
         this.SelectedObjList = new ObservableCollection<object>();
         this.SelectedStrList = new ObservableCollection<string>();
      }
      #endregion

      #region Override

      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();

         if (this.PART_FilterTextBox != null)
         {
            this.PART_FilterTextBox.TextChanged -= PART_FilterTextBox_TextChanged;
         }
         if (PART_Popup != null)
         {
            this.PART_Popup.Opened -= PART_Popup_Opened;
         }

         this.PART_ContentSite = this.GetTemplateChild("PART_ContentSite") as ContentPresenter;
         this.PART_FilterTextBox = this.GetTemplateChild("PART_FilterTextBox") as TextBox;
         this.PART_Popup = this.GetTemplateChild("PART_Popup") as Popup;
         if (this.PART_FilterTextBox != null)
         {
            this.PART_FilterTextBox.TextChanged += PART_FilterTextBox_TextChanged;
         }
         view = CollectionViewSource.GetDefaultView(this.ItemsSource);
         if (PART_Popup != null)
         {
            this.PART_Popup.Opened += PART_Popup_Opened;
         }
         this.Init();
      }
      protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
      {
         if (!(item is AduCheckComboBoxItem))
         {
            AduCheckComboBoxItem AduCheckComboBoxItem = element as AduCheckComboBoxItem;
            if (AduCheckComboBoxItem != null && !string.IsNullOrEmpty(this.DisplayMemberPath))
            {
               Binding binding = new Binding(this.DisplayMemberPath);
               AduCheckComboBoxItem.SetBinding(AduCheckComboBoxItem.ContentProperty, binding);
            }
         }

         base.PrepareContainerForItemOverride(element, item);
      }

      protected override DependencyObject GetContainerForItemOverride()
      {
         return new AduCheckComboBoxItem();
      }

      protected override bool IsItemItsOwnContainerOverride(object item)
      {
         return (item is AduCheckComboBoxItem);
      }

      #endregion

      #region PrivateFunction
      private void Init()
      {
         this.PopupIsFirstOpen = true;

         if (this.SelectedObjList != null)
         {
            foreach (var obj in this.SelectedObjList)
            {
               if (string.IsNullOrWhiteSpace(this.DisplayMemberPath))
               {
                  this.SelectedStrList.Add(obj.ToString());
               }
               else
               {
                  this.SelectedStrList.Add(VisualHelper.GetPropertyValue(obj, this.DisplayMemberPath).ToString());
               }
            }
         }
         this.SetAduCheckComboBoxValueAndContent();
      }

      private void SetAduCheckComboBoxValueAndContent()
      {
         if (SelectedObjList == null || SelectedObjList.Count <= 0)
            SelectedStrList = new ObservableCollection<string>();

         if (this.SelectedStrList == null) return;

         if (this.SelectedStrList.Count > this.MaxShowNumber)
            this.Content = $"选中{this.SelectedStrList.Count}个";
         else
            this.Content = this.SelectedStrList.Aggregate("", (current, p) => current + (p + ", ")).TrimEnd(new char[] { ' ' }).TrimEnd(new char[] { ',' });

         this.Value = this.SelectedStrList.Aggregate("", (current, p) => current + (p + ",")).TrimEnd(new char[] { ',' });
      }
      #endregion

      #region Internal
      /// <summary>
      /// 行选中
      /// </summary>
      /// <param name="item"></param>
      internal void NotifyAduCheckComboBoxItemClicked(AduCheckComboBoxItem item)
      {
         string itemContent = Convert.ToString(item.Content);
         if (this.SelectedStrList == null)
         {
            this.SelectedStrList = new ObservableCollection<string>();
         }
         if (this.SelectedObjList == null)
         {
            this.SelectedObjList = new ObservableCollection<object>();
         }
         if (item.IsSelected)
         {
            if (!this.SelectedStrList.Contains(item.Content))
            {
               this.SelectedStrList.Add(itemContent);
            }
            if (!this.SelectedObjList.Contains(item.DataContext))
            {
               this.SelectedObjList.Add(item.DataContext);
            }
         }
         else
         {
            if (this.SelectedStrList.Contains(itemContent))
            {
               this.SelectedStrList.Remove(itemContent);
            }
            if (this.SelectedObjList.Contains(item.DataContext))
            {
               this.SelectedObjList.Remove(item.DataContext);
            }
         }
         this.SetAduCheckComboBoxValueAndContent();
      }
      #endregion

      #region Event Implement Function
      /// <summary>
      /// 每次Open回显数据不太好，先这么处理
      /// </summary>
      private void PART_Popup_Opened(object sender, EventArgs e)
      {
         if (!this.PopupIsFirstOpen) return;

         this.PopupIsFirstOpen = false;

         if (this.ItemsSource == null || this.SelectedObjList == null) return;

         foreach (var obj in this.SelectedObjList)
         {
            AduCheckComboBoxItem AduCheckComboBoxItem = this.ItemContainerGenerator.ContainerFromItem(obj) as AduCheckComboBoxItem;
            if (AduCheckComboBoxItem != null)
               AduCheckComboBoxItem.IsSelected = true;
         }
      }
      /// <summary>
      /// 搜索关键字
      /// </summary>
      private void PART_FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         if (this.PART_FilterTextBox == null || view == null) return;

         view.Filter += (o) =>
         {
            string value = Convert.ToString(VisualHelper.GetPropertyValue(o, this.DisplayMemberPath)).ToLower();
            return value.IndexOf(this.PART_FilterTextBox.Text.ToLower()) != -1;
         };
         foreach (var obj in this.SelectedObjList)
         {
            AduCheckComboBoxItem AduCheckComboBoxItem = this.ItemContainerGenerator.ContainerFromItem(obj) as AduCheckComboBoxItem;
            if (AduCheckComboBoxItem != null)
               AduCheckComboBoxItem.IsSelected = true;
         }
      }
      #endregion
   }

   /// <summary>
   /// 选择行
   /// </summary>
   public class AduCheckComboBoxItem : ListBoxItem
   {
      #region PrivateProperty
      private AduCheckComboBox ParentAduCheckComboBox
      {
         get
         {
            return ItemsControl.ItemsControlFromItemContainer(this) as AduCheckComboBox;
         }
      }
      #endregion

      #region DependencyProperty
      public new static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected"
        , typeof(bool), typeof(AduCheckComboBoxItem), new PropertyMetadata(false, OnSelectedChanged));
      /// <summary>
      /// 选中
      /// </summary>
      public new bool IsSelected
      {
         get { return (bool)GetValue(IsSelectedProperty); }
         set { SetValue(IsSelectedProperty, value); }
      }
      private static void OnSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduCheckComboBoxItem ComboBoxItem = d as AduCheckComboBoxItem;
         if (ComboBoxItem.ParentAduCheckComboBox != null)
         {
            ComboBoxItem.ParentAduCheckComboBox.NotifyAduCheckComboBoxItemClicked(ComboBoxItem);
         }
      }
      #endregion

      #region Constructors
      static AduCheckComboBoxItem()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduCheckComboBoxItem), new FrameworkPropertyMetadata(typeof(AduCheckComboBoxItem)));
      }
      #endregion

      #region Override
      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();
      }
      #endregion
   }
}

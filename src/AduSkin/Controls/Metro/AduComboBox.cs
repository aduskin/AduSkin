using AduSkin.Utility.Element;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using AduSkin.Controls.Helper;
using System.Windows.Data;
using System.Collections;

namespace AduSkin.Controls.Metro
{
   public class AduComboBox : ComboBox
   {
      private TextBox PART_FilterTextBox;
      private ICollectionView view;
      public AduComboBox()
      {

      }
      static AduComboBox()
      {
         ElementBase.DefaultStyle<AduComboBox>(DefaultStyleKeyProperty);
      }

      #region 属性
      public static readonly DependencyProperty IsShowFilterBoxProperty =
          DependencyProperty.Register("IsShowFilterBox", typeof(bool), typeof(AduComboBox), new PropertyMetadata(false));
      /// <summary>
      /// 获取或者设置下拉列表过滤文本框的显示与隐藏
      /// </summary>
      public bool IsShowFilterBox
      {
         get { return (bool)GetValue(IsShowFilterBoxProperty) && ItemsSource != null; }
         set { SetValue(IsShowFilterBoxProperty, value); }
      }

      public static readonly DependencyProperty InputHintProperty = DependencyProperty.Register("InputHint"
            , typeof(string), typeof(AduComboBox));
      /// <summary>
      /// 文本输入框的水印
      /// </summary>
      public string InputHint
      {
         get { return (string)GetValue(InputHintProperty); }
         set { SetValue(InputHintProperty, value); }
      }

      public static readonly DependencyProperty ComBoxItemPanelBackgroundProperty = DependencyProperty.Register("ComBoxItemPanelBackground"
            , typeof(Brush), typeof(AduComboBox), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 255, 255))));
      /// <summary>
      /// 下拉列表背景色
      /// </summary>
      public Brush ComBoxItemPanelBackground
      {
         get { return (Brush)GetValue(ComBoxItemPanelBackgroundProperty); }
         set { SetValue(ComBoxItemPanelBackgroundProperty, value); }
      }

      public static readonly DependencyProperty ToggleButtonColorProperty = DependencyProperty.Register("ToggleButtonColor"
            , typeof(Brush), typeof(AduComboBox), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(238, 121, 111))));
      /// <summary>
      /// 下拉列表背景色
      /// </summary>
      public Brush ToggleButtonColor
      {
         get { return (Brush)GetValue(ToggleButtonColorProperty); }
         set { SetValue(ToggleButtonColorProperty, value); }
      }
      #endregion


      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();

         if (this.PART_FilterTextBox != null)
         {
            this.PART_FilterTextBox.TextChanged -= PART_FilterTextBox_TextChanged;
         }

         this.PART_FilterTextBox = this.GetTemplateChild("PART_FilterTextBox") as TextBox;
         if (this.PART_FilterTextBox != null)
         {
            this.PART_FilterTextBox.TextChanged += PART_FilterTextBox_TextChanged;
         }
      }

      private void PART_FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         if (this.PART_FilterTextBox == null)
            return;

         if (view != null)
         {
            view.Filter += (o) =>
            {
               if (o is string)
               {
                  string value = o.ToString().ToLower();
                  return value.IndexOf(this.PART_FilterTextBox.Text.ToLower(), StringComparison.Ordinal) != -1;
               }
               else
               {
                  string value = Convert.ToString(VisualHelper.GetPropertyValue(o, this.DisplayMemberPath)).ToLower();
                  return value.IndexOf(this.PART_FilterTextBox.Text.ToLower(), StringComparison.Ordinal) != -1;
               }
            };
         }
      }
      protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
      {
         base.OnItemsSourceChanged(oldValue, newValue);
         view = CollectionViewSource.GetDefaultView(this.ItemsSource);
      }
   }
}
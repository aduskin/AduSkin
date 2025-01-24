using AduSkin.Utility.Element;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
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
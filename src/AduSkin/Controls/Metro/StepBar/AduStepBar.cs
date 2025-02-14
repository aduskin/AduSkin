using System;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows;
using AduSkin.Utility.Element;

namespace AduSkin.Controls.Metro
{
   public class AduStepBar : ItemsControl
   {
      static AduStepBar()
      {
         ElementBase.DefaultStyle<AduStepBar>(DefaultStyleKeyProperty);
      }
      public int Progress
      {
         get { return (int)GetValue(ProgressProperty); }
         set { SetValue(ProgressProperty, value); }
      }

      public static readonly DependencyProperty ProgressProperty =
          DependencyProperty.Register("Progress", typeof(int), typeof(AduStepBar), new PropertyMetadata(0, OnProgressChangedCallback, OnProgressCoerceValueCallback));

      private static object OnProgressCoerceValueCallback(DependencyObject d, object baseValue)
      {
         AduStepBar stepBar = d as AduStepBar;
         int newValue = Convert.ToInt32(baseValue);
         if (newValue < 0)
         {
            return 0;
         }
         else if (newValue >= stepBar.Items.Count)
         {
            return stepBar.Items.Count - 1;
         }
         return newValue;
      }

      private static void OnProgressChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {

      }
      protected override DependencyObject GetContainerForItemOverride()
      {
         return new AduStepBarItem();
      }

      /// <summary>
      /// 设置Item的显示数字
      /// </summary> 
      protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
      {
         AduStepBarItem stepBarItem = element as AduStepBarItem;
         ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(stepBarItem);
         int index = itemsControl.ItemContainerGenerator.IndexFromContainer(stepBarItem);
         stepBarItem.Number = Convert.ToString(++index);
         base.PrepareContainerForItemOverride(element, item);
      }

      /// <summary>
      /// ItemsControl数量变化时，重新设置各个Item的显示的数字
      /// </summary> 
      protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
      {
         base.OnItemsChanged(e);

         for (int i = 0; i < this.Items.Count; i++)
         {
            AduStepBarItem stepBarItem = this.ItemContainerGenerator.ContainerFromIndex(i) as AduStepBarItem;
            if (stepBarItem != null)
            {
               int temp = i;
               stepBarItem.Number = Convert.ToString(++temp);
            }
         }
         //进度重新回到第一个
         this.Progress = 0;
      }
   }
}

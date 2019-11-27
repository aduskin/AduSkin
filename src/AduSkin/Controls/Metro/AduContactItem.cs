using AduSkin.Controls.Data;
using AduSkin.Controls.Metro.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AduSkin.Controls.Metro
{
   public class AduContactItem : SelectableItem
   {
      //头像
      public static readonly DependencyProperty HeaderImageProperty = DependencyProperty.Register(
          "HeaderImage", typeof(string), typeof(AduContactItem), new PropertyMetadata(default(string)));

      public string HeaderImage
      {
         get => (string)GetValue(HeaderImageProperty);
         set => SetValue(HeaderImageProperty, value);
      }
      //序号ID
      public static readonly DependencyProperty SortIDProperty = DependencyProperty.Register(
            "SortID", typeof(string), typeof(AduContactItem), new PropertyMetadata(default(string)));

      public string SortID
      {
         get => (string)GetValue(SortIDProperty);
         set => SetValue(SortIDProperty, value);
      }

      //显示名称
      public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
            "UserName", typeof(string), typeof(AduContactItem), new PropertyMetadata(default(string)));

      public string UserName
      {
         get => (string)GetValue(UserNameProperty);
         set => SetValue(UserNameProperty, value);
      }

      //组、单一个人
      public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
            "Type", typeof(ContactType), typeof(AduContactItem), new PropertyMetadata(default(ContactType)));

      public ContactType Type
      {
         get => (ContactType)GetValue(TypeProperty);
         set => SetValue(TypeProperty, value);
      }
      
      public static void SetMaxWidth(DependencyObject element, double value)
          => element.SetValue(MaxWidthProperty, value);

      public static double GetMaxWidth(DependencyObject element)
          => (double)element.GetValue(MaxWidthProperty);

      public Action<object> ReadAction { get; set; }

      protected override void OnSelected(RoutedEventArgs e)
      {
         base.OnSelected(e);

         ReadAction?.Invoke(Content);
      }
   }
}

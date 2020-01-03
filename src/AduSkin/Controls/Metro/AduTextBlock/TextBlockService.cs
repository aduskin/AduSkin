using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class TextBlockService
   {


      /// <summary>
      /// 从指定元素获取 HighlightText 依赖项属性的值。
      /// </summary>
      /// <param name="obj">从中读取属性值的元素。</param>
      /// <returns>从属性存储获取的属性值。</returns>
      public static TextBlockHighlightSource GetHighlightText(TextBlock textBlock) => (TextBlockHighlightSource)textBlock.GetValue(HighlightTextProperty);

      /// <summary>
      /// 将 HighlightText 依赖项属性的值设置为指定元素。
      /// </summary>
      /// <param name="obj">对其设置属性值的元素。</param>
      /// <param name="value">要设置的值。</param>
      public static void SetHighlightText(TextBlock textBlock, TextBlockHighlightSource value) => textBlock.SetValue(HighlightTextProperty, value);

      /// <summary>
      /// 标识 HighlightText 依赖项属性。
      /// </summary>
      public static readonly DependencyProperty HighlightTextProperty =
          DependencyProperty.RegisterAttached("HighlightText", typeof(TextBlockHighlightSource), typeof(TextBlockService), new PropertyMetadata(null, OnHighlightTextChanged));


      private static void OnHighlightTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
      {
         var oldValue = (TextBlockHighlightSource)args.OldValue;
         var newValue = (TextBlockHighlightSource)args.NewValue;
         if (oldValue == newValue)
            return;

         void OnPropertyChanged(object sender, EventArgs e)
         {
            if (obj is TextBlock target)
            {
               MarkHighlight(target, newValue);
            }
         };

         if (oldValue != null)
            newValue.PropertyChanged -= OnPropertyChanged;

         if (newValue != null)
            newValue.PropertyChanged += OnPropertyChanged;

         OnPropertyChanged(null, null);
      }


      ///// <summary>
      ///// 标识 HighlightText 依赖项属性。
      ///// </summary>
      //public static readonly DependencyProperty HighlightTextProperty =
      //    DependencyProperty.RegisterAttached("HighlightText", typeof(string), typeof(TextBlockService), new PropertyMetadata(default(string), OnHighlightTextChanged));

      private static readonly Brush _noHighlightBrush = new SolidColorBrush(Color.FromArgb(168, 0, 0, 0));

      ///// <summary>
      ///// 从指定元素获取 HighlightText 依赖项属性的值。
      ///// </summary>
      ///// <param name="obj">从中读取属性值的元素。</param>
      ///// <returns>从属性存储获取的属性值。</returns>
      //public static string GetHighlightText(TextBlock obj) => (string)obj.GetValue(HighlightTextProperty);

      ///// <summary>
      ///// 将 HighlightText 依赖项属性的值设置为指定元素。
      ///// </summary>
      ///// <param name="obj">对其设置属性值的元素。</param>
      ///// <param name="value">要设置的值。</param>
      //public static void SetHighlightText(TextBlock obj, string value) => obj.SetValue(HighlightTextProperty, value);

      //private static void OnHighlightTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
      //{
      //    var oldValue = (string)args.OldValue;
      //    var newValue = (string)args.NewValue;
      //    if (oldValue == newValue)
      //        return;

      //    if (obj is TextBlock target)
      //    {
      //        MarkHighlight(target, newValue);
      //    }
      //}

      private static void MarkHighlight(TextBlock target, string highlightText)
      {
         var text = target.Text;
         target.Inlines.Clear();
         if (string.IsNullOrWhiteSpace(text))
            return;

         if (string.IsNullOrWhiteSpace(highlightText))
         {
            target.Inlines.Add(new Run { Text = text });
            return;
         }

         while (text.Length > 0)
         {
            var runText = string.Empty;
            var index = text.IndexOf(highlightText, StringComparison.InvariantCultureIgnoreCase);
            if (index > 0)
            {
               runText = text.Substring(0, index);
               target.Inlines.Add(new Run { Text = runText, Foreground = _noHighlightBrush });
            }
            else if (index == 0)
            {
               runText = text.Substring(0, highlightText.Length);
               target.Inlines.Add(new Run { Text = runText });
            }
            else if (index == -1)
            {
               runText = text;
               target.Inlines.Add(new Run { Text = runText, Foreground = _noHighlightBrush });
            }

            text = text.Substring(runText.Length);
         }
      }


      private static void MarkHighlight(TextBlock target, TextBlockHighlightSource highlightSource)
      {
         var text = target.Text;
         target.Inlines.Clear();
         if (string.IsNullOrWhiteSpace(text))
            return;

         if (string.IsNullOrWhiteSpace(highlightSource.Text))
         {
            target.Inlines.Add(new Run { Text = text });
            return;
         }

         while (text.Length > 0)
         {
            var runText = string.Empty;
            var index = text.IndexOf(highlightSource.Text, StringComparison.InvariantCultureIgnoreCase);
            if (index > 0)
            {
               runText = text.Substring(0, index);
               var run = new Run
               {
                  Text = runText,
               };
               if (highlightSource.LowlightForeground != null)
                  run.Foreground = highlightSource.LowlightForeground;

               target.Inlines.Add(run);
            }
            else if (index == 0)
            {
               runText = text.Substring(0, highlightSource.Text.Length);
               var run = new Run { Text = runText };
               if (highlightSource.HighlightForeground != null)
                  run.Foreground = highlightSource.HighlightForeground;

               if (highlightSource.HighlightBackground != null)
                  run.Background = highlightSource.HighlightBackground;

               target.Inlines.Add(run);
            }
            else if (index == -1)
            {
               runText = text;
               var run = new Run
               {
                  Text = runText,
               };
               if (highlightSource.LowlightForeground != null)
                  run.Foreground = highlightSource.LowlightForeground;

               target.Inlines.Add(run);
            }

            text = text.Substring(runText.Length);
         }
      }
   }
}

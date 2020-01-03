using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   [TypeConverter(typeof(TextBlockHighlightSourceConverter))]
   public class TextBlockHighlightSource : FrameworkElement
   {
      /// <summary>
      /// 标识 HighlightForeground 依赖属性。
      /// </summary>
      public static readonly DependencyProperty HighlightForegroundProperty =
          DependencyProperty.Register(nameof(HighlightForeground), typeof(Brush), typeof(TextBlockHighlightSource), new PropertyMetadata(default(Brush), OnPropertyChanged));

      /// <summary>
      /// 标识 LowlightForeground 依赖属性。
      /// </summary>
      public static readonly DependencyProperty LowlightForegroundProperty =
          DependencyProperty.Register(nameof(LowlightForeground), typeof(Brush), typeof(TextBlockHighlightSource), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(168, 0, 0, 0)), OnPropertyChanged));

      /// <summary>
      /// 标识 HighlightBackground 依赖属性。
      /// </summary>
      public static readonly DependencyProperty HighlightBackgroundProperty =
          DependencyProperty.Register(nameof(HighlightBackground), typeof(Brush), typeof(TextBlockHighlightSource), new PropertyMetadata(default(Brush), OnPropertyChanged));

      /// <summary>
      /// 标识 Text 依赖属性。
      /// </summary>
      public static readonly DependencyProperty TextProperty =
          DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextBlockHighlightSource), new PropertyMetadata(default(string), OnPropertyChanged));

      public TextBlockHighlightSource()
      {
      }

      public event EventHandler PropertyChanged;

      /// <summary>
      /// 获取或设置HighlightForeground的值
      /// </summary>
      public Brush HighlightForeground
      {
         get => (Brush)GetValue(HighlightForegroundProperty);
         set => SetValue(HighlightForegroundProperty, value);
      }

      /// <summary>
      /// 获取或设置LowlightForeground的值
      /// </summary>
      public Brush LowlightForeground
      {
         get => (Brush)GetValue(LowlightForegroundProperty);
         set => SetValue(LowlightForegroundProperty, value);
      }

      /// <summary>
      /// 获取或设置HighlightBackground的值
      /// </summary>
      public Brush HighlightBackground
      {
         get => (Brush)GetValue(HighlightBackgroundProperty);
         set => SetValue(HighlightBackgroundProperty, value);
      }


      /// <summary>
      /// 获取或设置Text的值
      /// </summary>
      public string Text
      {
         get => (string)GetValue(TextProperty);
         set => SetValue(TextProperty, value);
      }

      private static void OnPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
      {
         var oldValue = args.OldValue;
         var newValue = args.NewValue;
         if (oldValue == newValue)
            return;

         var target = obj as TextBlockHighlightSource;
         target?.OnPropertyChanged();
      }


      protected virtual void OnPropertyChanged()
      {
         PropertyChanged?.Invoke(this, EventArgs.Empty);
      }
   }
}

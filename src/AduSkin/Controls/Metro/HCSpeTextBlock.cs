using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
   /// <summary>
   ///     作为刻度使用的文字块
   /// </summary>
   internal class HCSpeTextBlock : TextBlock
   {
      public double X { get; set; }

      public HCSpeTextBlock() => Width = 60;

      public HCSpeTextBlock(double x) : this()
      {
         X = x;
         Canvas.SetLeft(this, X);
      }

      /// <summary>
      ///     时间
      /// </summary>
      private DateTime _time;

      /// <summary>
      ///     时间
      /// </summary>
      public DateTime Time
      {
         get => _time;
         set
         {
            _time = value;
            Text = $"{value.ToString(TimeFormat)}\r\n|";
         }
      }

      /// <summary>
      ///     时间格式
      /// </summary>
      public string TimeFormat { get; set; } = "HH:mm";

      /// <summary>
      ///     横向移动
      /// </summary>
      /// <param name="offsetX"></param>
      public void MoveX(double offsetX) => Canvas.SetLeft(this, X + offsetX);
   }
}

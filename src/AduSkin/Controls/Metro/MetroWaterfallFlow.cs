using AduSkin.Utility.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
   public class MetroWaterfallFlow : Panel
   {
      private int _colums = 0;
      private double _actualListWidth;
      private double _maxheight;
      private double _panelWidth;
      private double[] _curHeight;

      public double ListWidth { get; set; } = 200;
      static MetroWaterfallFlow()
      {
         ElementBase.DefaultStyle<MetroWaterfallFlow>(DefaultStyleKeyProperty);
      }
      public MetroWaterfallFlow()
      {

      }

      protected override Size MeasureOverride(Size constraint)
      {
         if (double.IsInfinity(constraint.Width))
         {
            _colums = InternalChildren.Count;
            _actualListWidth = ListWidth;
            _panelWidth = _actualListWidth * _colums;
         }
         else
         {
            _colums = (int)Math.Floor(constraint.Width / ListWidth);
            _actualListWidth = constraint.Width / _colums;
            _panelWidth = constraint.Width;
         }
         _curHeight = new double[_colums];
         foreach (UIElement item in InternalChildren)
         {
            var col = GetFistMiniHeight();
            item.SetValue(WidthProperty, _actualListWidth);
            item.Measure(new Size(_actualListWidth, double.PositiveInfinity));
            SetCurHeight(col, item.DesiredSize.Height);
         }
         return new Size(_panelWidth, _maxheight);
      }

      protected override Size ArrangeOverride(Size arrangeSize)
      {
         _curHeight = new double[_colums];
         for (int i = 0; i < InternalChildren.Count; i++)
         {
            var item = InternalChildren[i];
            var col = GetFistMiniHeight();
            var rect = new Rect(_actualListWidth * col, _curHeight[col], _actualListWidth, item.DesiredSize.Height);
            SetCurHeight(col, item.DesiredSize.Height);
            item.Arrange(rect);
         }
         return base.ArrangeOverride(arrangeSize);
      }

      /// <summary>
      /// 更新当前的高度数组,并设置面板的高度
      /// </summary>
      /// <param name="i"></param>
      /// <param name="value"></param>
      private void SetCurHeight(int i, double value)
      {
         _curHeight[i] += value;
         _maxheight = Math.Max(_curHeight[i], _maxheight);
      }

      /// <summary>
      /// 获取当前高度最低列
      /// </summary>
      /// <returns></returns>
      private int GetFistMiniHeight()
      {
         int ret = -1;
         double min = _curHeight.Last();
         for (int i = _colums - 1; i >= 0; i--)
         {
            if (_curHeight[i] <= min)
            {
               min = _curHeight[i];
               ret = i;
            }
         }
         return ret;
      }
   }
}
using AduSkin.Utility.Element;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class MetroWaterfallFlow : Canvas
    {
        int column;
        double listWidth = 200;
        public double ListWidth { get { return listWidth; } set { listWidth = value; SetColumn(); } }
        static MetroWaterfallFlow()
        {
            ElementBase.DefaultStyle<MetroWaterfallFlow>(DefaultStyleKeyProperty);
        }
        public MetroWaterfallFlow()
        {
            Loaded += delegate
            {
                SetColumn();
                Margin = new Thickness(Margin.Left);
            };
            SizeChanged += delegate
            {
                SetColumn();
            };
        }

        void SetColumn()
        {
            // MinWidth = listWidth + Margin.Left * 4;
            column = (int)(ActualWidth / listWidth);
            if (column <= 0) column = 1;
            Refresh();
        }

        public void Add(FrameworkElement element)
        {
            element.Width = ListWidth;
            if (element is Grid)
            {
                if ((element as Grid).Children.Count > 0)
                {
                    ((element as Grid).Children[0] as FrameworkElement).Margin = new Thickness(Margin.Left);
                }
            }
            Children.Add(element);
            Refresh();
        }

        public class Point
        {
            public int Index { get; set; }
            public double Buttom { get; set; }
            public double Height { get; set; }
            public Point(int index, double height, double buttom) { Index = index;Height = height; Buttom = buttom; }
        }

        public void Refresh()
        {
            // 初始化参数
            var maxHeight = 0.0;
            var list = new Dictionary<int, Point>();
            var nlist = new Dictionary<int, Dictionary<int, Point>>();
            for (int i = 0; i < Children.Count; i++)
            {
                (Children[i] as FrameworkElement).UpdateLayout();
                list.Add(i, new Point(i,(Children[i] as FrameworkElement).ActualHeight, 0.0));
            }
            for (int i = 0; i < column; i++)
            {
                nlist.Add(i, new Dictionary<int, Point>());
            }

            // 智能排序到 nlist
            for (int i = 0; i < list.Count; i++)
            {
                if (i < column)
                {
                    list[i].Buttom = list[i].Height;
                    nlist[i].Add(nlist[i].Count, list[i]);
                }
                else
                {
                    var b = 0.0;
                    var l = 0;
                    for (int j = 0; j < column; j++)
                    {
                        var jh = nlist[j][nlist[j].Count - 1].Buttom + list[i].Height;
                        if (b == 0.0 || jh < b)
                        {
                            b = jh;
                            l = j;
                        }
                    }
                    list[i].Buttom = b;
                    nlist[l].Add(nlist[l].Count, list[i]);
                }
            }

            // 开始布局
            for (int i = 0; i < nlist.Count; i++)
            {
                for (int j = 0; j < nlist[i].Count; j++)
                {
                    Children[nlist[i][j].Index].SetValue(LeftProperty, i * ActualWidth / column);
                    Children[nlist[i][j].Index].SetValue(TopProperty, nlist[i][j].Buttom - nlist[i][j].Height);
                    Children[nlist[i][j].Index].SetValue(WidthProperty, ActualWidth / column);

                    if (Children[nlist[i][j].Index] is Grid)
                    {
                        ((Children[nlist[i][j].Index] as Grid).Children[0] as FrameworkElement).Margin = Margin;
                    }
                }

                // 不知道为什么如果不写这么一句会出错
                if (nlist.ContainsKey(i))
                {
                    if (nlist[i].ContainsKey(nlist[i].Count - 1))
                    {
                        var mh = nlist[i][nlist[i].Count - 1].Buttom;
                        maxHeight = mh > maxHeight ? mh : maxHeight;
                    }
                }
            }
            Height = maxHeight;
            list.Clear();
            nlist.Clear();
        }

        public void Remove(UIElement element)
        {
            Children.Remove(element);
            Refresh();
        }
    }
}
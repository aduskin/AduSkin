using AduSkin.Controls.Data;
using AduSkin.Controls.Tools;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public class AduManageableTabPanel : Panel
    {
        private int _itemCount;

        /// <summary>
        ///     是否可以更新
        /// </summary>
        internal bool CanUpdate = true;

        /// <summary>
        ///     选项卡字典
        /// </summary>
        internal Dictionary<int, AduManageableTabItem> ItemDic = new Dictionary<int, AduManageableTabItem>();

        /// <summary>
        ///     流式行为持续时间
        /// </summary>
        public static readonly DependencyProperty FluidMoveDurationProperty = DependencyProperty.Register(
            "FluidMoveDuration", typeof(Duration), typeof(AduManageableTabPanel), new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(200))));

        /// <summary>
        ///     流式行为持续时间
        /// </summary>
        public Duration FluidMoveDuration
        {
            get => (Duration)GetValue(FluidMoveDurationProperty);
            set => SetValue(FluidMoveDurationProperty, value);
        }

        /// <summary>
        ///     是否将标签填充
        /// </summary>
        public static readonly DependencyProperty IsEnableTabFillProperty = DependencyProperty.Register(
            "IsEnableTabFill", typeof(bool), typeof(AduManageableTabPanel), new PropertyMetadata(ValueBoxes.FalseBox));

        /// <summary>
        ///     是否将标签填充
        /// </summary>
        public bool IsEnableTabFill
        {
            get => (bool)GetValue(IsEnableTabFillProperty);
            set => SetValue(IsEnableTabFillProperty, value);
        }

        /// <summary>
        ///     标签宽度
        /// </summary>
        public static readonly DependencyProperty TabItemWidthProperty = DependencyProperty.Register(
            "TabItemWidth", typeof(double), typeof(AduManageableTabPanel), new PropertyMetadata(200.0));

        /// <summary>
        ///     标签宽度
        /// </summary>
        public double TabItemWidth
        {
            get => (double)GetValue(TabItemWidthProperty);
            set => SetValue(TabItemWidthProperty, value);
        }

        /// <summary>
        ///     标签高度
        /// </summary>
        public static readonly DependencyProperty TabItemHeightProperty = DependencyProperty.Register(
            "TabItemHeight", typeof(double), typeof(AduManageableTabPanel), new PropertyMetadata(30.0));

        /// <summary>
        ///     标签高度
        /// </summary>
        public double TabItemHeight
        {
            get => (double)GetValue(TabItemHeightProperty);
            set => SetValue(TabItemHeightProperty, value);
        }

        /// <summary>
        ///     是否可以强制更新
        /// </summary>
        internal bool ForceUpdate;

        private Size _oldSize;

        /// <summary>
        ///     是否已经加载
        /// </summary>
        private bool _isLoaded;

        protected override Size MeasureOverride(Size constraint)
        {
            if ((_itemCount == InternalChildren.Count || !CanUpdate) && !ForceUpdate) return _oldSize;
            constraint.Height = TabItemHeight;
            _itemCount = InternalChildren.Count;

            var size = new Size();

            ItemDic.Clear();

            var count = InternalChildren.Count;
            if (count == 0)
            {
                _oldSize = new Size();
                return _oldSize;
            }
            constraint.Width += InternalChildren.Count;

            var itemWidth = .0;
            var arr = new int[count];

            if (!IsEnableTabFill)
            {
                itemWidth = TabItemWidth;
            }
            else
            {
                if (TemplatedParent is TabControl tabControl)
                {
                    arr = ArithmeticHelper.DivideInt2Arr((int)tabControl.ActualWidth + InternalChildren.Count, count);
                }
            }

            for (var index = 0; index < count; index++)
            {
                if (IsEnableTabFill)
                {
                    itemWidth = arr[index];
                }
                if (InternalChildren[index] is AduManageableTabItem tabItem)
                {
                    tabItem.RenderTransform = new TranslateTransform();
                    tabItem.MaxWidth = itemWidth;
                    var rect = new Rect
                    {
                        X = size.Width - tabItem.BorderThickness.Left,
                        Width = itemWidth,
                        Height = TabItemHeight
                    };
                    tabItem.Arrange(rect);
                    tabItem.ItemWidth = itemWidth - tabItem.BorderThickness.Left;
                    tabItem.CurrentIndex = index;
                    tabItem.TargetOffsetX = 0;
                    ItemDic[index] = tabItem;
                    size.Width += tabItem.ItemWidth;
                }
            }
            size.Height = constraint.Height;
            _oldSize = size;
            return _oldSize;
        }

        public AduManageableTabPanel()
        {
            Loaded += (s, e) =>
            {
                if (_isLoaded) return;
                ForceUpdate = true;
                Measure(new Size(DesiredSize.Width, ActualHeight));
                ForceUpdate = false;
                foreach (var item in ItemDic.Values)
                {
                    item.TabPanel = this;
                }
                _isLoaded = true;
            };
        }
    }
}
using AduSkin.Controls.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AduSkin.Controls.Metro
{
    public class AduNavigationPanel : ContentControl
    {
        #region private fields

        private SegmentControl PART_Indicator;
        private ContentPresenter PART_ContentPresenter;

        private ScrollViewer mScrollViewer;
        private List<AduGroupBoxNor> mHeaderList;


        #endregion

        #region DependencyProperty

        #region ItemsSource

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            private set { SetValue(ItemsSourceProperty, value); }
        }
        
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(AduNavigationPanel));

        #endregion

        #region IndicatorStyle

        public Style IndicatorStyle
        {
            get { return (Style)GetValue(IndicatorStyleProperty); }
            set { SetValue(IndicatorStyleProperty, value); }
        }
        
        public static readonly DependencyProperty IndicatorStyleProperty =
            DependencyProperty.Register("IndicatorStyle", typeof(Style), typeof(AduNavigationPanel), new PropertyMetadata(null));

        #endregion

        #region IndicatorItemContainerStyle

        public Style IndicatorItemContainerStyle
        {
            get { return (Style)GetValue(IndicatorItemContainerStyleProperty); }
            set { SetValue(IndicatorItemContainerStyleProperty, value); }
        }
        
        public static readonly DependencyProperty IndicatorItemContainerStyleProperty =
            DependencyProperty.Register("IndicatorItemContainerStyle", typeof(Style), typeof(AduNavigationPanel), new PropertyMetadata(null));

        #endregion

        #region IndicatorItemsPanel

        public ItemsPanelTemplate IndicatorItemsPanel
        {
            get { return (ItemsPanelTemplate)GetValue(IndicatorItemsPanelProperty); }
            set { SetValue(IndicatorItemsPanelProperty, value); }
        }
        
        public static readonly DependencyProperty IndicatorItemsPanelProperty =
            DependencyProperty.Register("IndicatorItemsPanel", typeof(ItemsPanelTemplate), typeof(AduNavigationPanel));

        #endregion

        #region IndicatorPlacement

        public Dock IndicatorPlacement
        {
            get { return (Dock)GetValue(IndicatorPlacementProperty); }
            set { SetValue(IndicatorPlacementProperty, value); }
        }
        
        public static readonly DependencyProperty IndicatorPlacementProperty =
            DependencyProperty.Register("IndicatorPlacement", typeof(Dock), typeof(AduNavigationPanel), new PropertyMetadata(Dock.Top));

        #endregion

        #region IndicatorMargin

        public Thickness IndicatorMargin
        {
            get { return (Thickness)GetValue(IndicatorMarginProperty); }
            set { SetValue(IndicatorMarginProperty, value); }
        }
        
        public static readonly DependencyProperty IndicatorMarginProperty =
            DependencyProperty.Register("IndicatorMargin", typeof(Thickness), typeof(AduNavigationPanel));

        #endregion

        #region IndicatorHorizontalAlignment

        public HorizontalAlignment IndicatorHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(IndicatorHorizontalAlignmentProperty); }
            set { SetValue(IndicatorHorizontalAlignmentProperty, value); }
        }
        
        public static readonly DependencyProperty IndicatorHorizontalAlignmentProperty =
            DependencyProperty.Register("IndicatorHorizontalAlignment", typeof(HorizontalAlignment)
                , typeof(AduNavigationPanel));

        #endregion

        #region IndicatorSelectedIndex

        public int IndicatorSelectedIndex
        {
            get { return (int)GetValue(IndicatorSelectedIndexProperty); }
            set { SetValue(IndicatorSelectedIndexProperty, value); }
        }
        
        public static readonly DependencyProperty IndicatorSelectedIndexProperty =
            DependencyProperty.Register("IndicatorSelectedIndex", typeof(int), typeof(AduNavigationPanel), new PropertyMetadata(0, IndicatorSelectedIndexCallback));

        private static void IndicatorSelectedIndexCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AduNavigationPanel navigationPanel = d as AduNavigationPanel;
            int index = (int)e.NewValue;
            if (navigationPanel != null && navigationPanel.mHeaderList != null && index < navigationPanel.mHeaderList.Count)
            {
                object item = navigationPanel.mHeaderList[index];
                navigationPanel.ScrollToSelection(item);
            }
        }

        #endregion

        #endregion

        #region Constructors

        static AduNavigationPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduNavigationPanel), new FrameworkPropertyMetadata(typeof(AduNavigationPanel)));
        }

        #endregion

        #region Override

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.Loaded += NavigationPanel_Loaded;
            this.PART_Indicator = this.GetTemplateChild("PART_Indicator") as SegmentControl;
            this.PART_ContentPresenter = this.GetTemplateChild("PART_ContentPresenter") as ContentPresenter;
            if (this.PART_Indicator != null)
            {
                this.PART_Indicator.ItemClick += PART_Indicator_ItemClick;
            }
        }

        #endregion

        #region private function

        /// <summary>
        /// 滚动至指定Item
        /// </summary>
        /// <param name="selection"></param>
        private void ScrollToSelection(object selection)
        {
            if (this.mScrollViewer == null)
            {
                return;
            }

            for (int i = 0; i < this.mHeaderList.Count; i++)
            {
                if (this.mHeaderList[i] == selection)
                {
                    //获取子项相对于控件的位置
                    GeneralTransform generalTransform1 = this.mHeaderList[i].TransformToAncestor(this.PART_ContentPresenter);
                    Point currentPoint = generalTransform1.Transform(new Point(0, 0));

                    double offsetY = this.mScrollViewer.VerticalOffset + currentPoint.Y;

                    this.mScrollViewer.ScrollToVerticalOffset(offsetY);

                    //DoubleAnimation doubleAnimation = new DoubleAnimation(this.oldOffsetY, offsetY, new Duration(TimeSpan.FromMilliseconds(500)));
                    //this.mScrollViewer.BeginAnimation(ZScrollViewer.VerticalOffsetExProperty, doubleAnimation);

                    //this.oldOffsetY = offsetY;
                    //this.IndicatorSelectedIndex = i;
                    break;
                }
            }
        }

        #endregion

        #region Event Implement Function

        private void NavigationPanel_Loaded(object sender, RoutedEventArgs e)
        {
            mHeaderList = VisualHelper.FindVisualChildrenEx<AduGroupBoxNor>(this.PART_ContentPresenter);
            if (mHeaderList != null)
            {
                List<object> list = new List<object>();
                mHeaderList.ForEach(p => list.Add(p));
                this.ItemsSource = list;
            }
            this.mScrollViewer = VisualHelper.FindVisualChild<ScrollViewer>(this.PART_ContentPresenter);
            if (this.mScrollViewer != null)
            {
                this.mScrollViewer.ScrollChanged += MScrollViewer_ScrollChanged;
            }

            object item = this.mHeaderList[this.IndicatorSelectedIndex];
            this.ScrollToSelection(item);
        }

        /// <summary>
        /// 点击指示器，滚动至指定位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PART_Indicator_ItemClick(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var item = this.PART_Indicator.SelectedItem;
            this.ScrollToSelection(item);
        }

        /// <summary>
        /// 当滚动条位置发生改变时，选中指示器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var verticalOffset = this.mScrollViewer.VerticalOffset;
            if (verticalOffset > 0)
            {
                double scrollOffset = 0.0;
                for (int i = 0; i < this.mHeaderList.Count; i++)
                {
                    var child = this.mHeaderList[i];
                    if (child is FrameworkElement)
                    {
                        FrameworkElement element = child as FrameworkElement;
                        if (element == null) return;

                        scrollOffset += element.ActualHeight;

                        if (scrollOffset > verticalOffset && i < this.mHeaderList.Count)
                        {
                            //this.IndicatorSelectedIndex = i;
                            this.PART_Indicator.SelectedItem = this.mHeaderList[i];
                            break;
                        }
                    }
                }
            }
        }

        #endregion
    }
}

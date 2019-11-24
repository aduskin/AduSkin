using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace AduSkin.Controls.Metro
{
    public class AduUpload : ButtonBase
    {
        #region Private属性

        #endregion

        #region 依赖属性定义
        public static readonly DependencyProperty MultiSelectProperty;
        public static readonly DependencyProperty FilterProperty;
        #endregion

        #region 依赖属性set get
        /// <summary>
        /// 是否可以选择多个文件
        /// </summary>
        public bool MultiSelect
        {
            get { return (bool)GetValue(MultiSelectProperty); }
            set { SetValue(MultiSelectProperty, value); }
        }

        /// <summary>
        /// 文件过滤器
        /// </summary>
        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }
        #endregion

        #region 路由事件
        public static readonly RoutedEvent AduUploadEvent;

        public event RoutedPropertyChangedEventHandler<object> FileAduUpload
        {
            add
            {
                base.AddHandler(AduUploadEvent, value);
            }
            remove
            {
                base.RemoveHandler(AduUploadEvent, value);
            }
        }

        protected virtual void OnFileAduUpload(object oldValue, object newValue)
        {
            RoutedPropertyChangedEventArgs<object> arg =
                new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, AduUploadEvent);
            this.RaiseEvent(arg);
        }
        #endregion

        #region Constructors
        static AduUpload()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduUpload), new FrameworkPropertyMetadata(typeof(AduUpload)));

            MultiSelectProperty = DependencyProperty.Register("MultiSelect", typeof(bool), typeof(AduUpload));
            FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(AduUpload));

            AduUploadEvent = EventManager.RegisterRoutedEvent("FileAduUpload"
                , RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>)
                , typeof(AduUpload));
        }
        #endregion

        #region Override方法
        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Array files = (System.Array)e.Data.GetData(DataFormats.FileDrop);
                this.OnFileAduUpload(null, files);
            }
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //    e.Effects = DragDropEffects.Link;
            //else e.Effects = DragDropEffects.None;
        }

        protected override void OnClick()
        {
            base.OnClick();

            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Multiselect = this.MultiSelect;
            //"文本文件|*.*|C#文件|*.cs|所有文件|*.*"
            openFileDialog.Filter = this.Filter;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = openFileDialog.FileNames;
                this.OnFileAduUpload(null, files);
            }
        }
        #endregion

        #region Private方法

        #endregion
    }
}

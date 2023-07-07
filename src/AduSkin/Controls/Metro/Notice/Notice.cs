using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AduSkin.Controls.Metro
{
    public class Notice : ItemsControl
    {
        #region Private属性

        #endregion

        #region 依赖属性定义
        /// <summary>
        /// 通知标题
        /// </summary>
        public static readonly DependencyProperty TitleMemberPathProperty;
        /// <summary>
        /// 通知内容
        /// </summary>
        public static readonly DependencyProperty ContentMemberPathProperty;
        /// <summary>
        /// 通知类型
        /// </summary>
        public static readonly DependencyProperty NoticeTypeMemberPathProperty;
        #endregion

        #region 依赖属性set get
        /// <summary>
        /// 通知标题
        /// </summary>
        public string TitleMemberPath
        {
            get { return (string)GetValue(TitleMemberPathProperty); }
            set { SetValue(TitleMemberPathProperty, value); }
        }

        /// <summary>
        /// 通知内容
        /// </summary>
        public string ContentMemberPath
        {
            get { return (string)GetValue(ContentMemberPathProperty); }
            set { SetValue(ContentMemberPathProperty, value); }
        }

        /// <summary>
        /// 通知类型
        /// </summary>
        public string NoticeTypeMemberPath
        {
            get { return (string)GetValue(NoticeTypeMemberPathProperty); }
            set { SetValue(NoticeTypeMemberPathProperty, value); }
        }
        #endregion

        #region Constructors
        static Notice()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Notice), new FrameworkPropertyMetadata(typeof(Notice)));
            Notice.TitleMemberPathProperty = DependencyProperty.Register("TitleMemberPath", typeof(string), typeof(Notice));
            Notice.ContentMemberPathProperty = DependencyProperty.Register("ContentMemberPath", typeof(string), typeof(Notice));
            Notice.NoticeTypeMemberPathProperty = DependencyProperty.Register("NoticeTypeMemberPath", typeof(string), typeof(Notice));
        }
        #endregion

        #region Override方法
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);

            NoticeItem noticeItem = element as NoticeItem;
            if(!string.IsNullOrEmpty(this.TitleMemberPath))
            {
                Binding binding = new Binding(this.TitleMemberPath);
                noticeItem.SetBinding(NoticeItem.TitleProperty, binding);
            }
            if (!string.IsNullOrEmpty(this.ContentMemberPath))
            {
                Binding binding = new Binding(this.ContentMemberPath);
                noticeItem.SetBinding(NoticeItem.ContentProperty, binding);
            }
            if (!string.IsNullOrEmpty(this.NoticeTypeMemberPath))
            {
                Binding binding = new Binding(this.NoticeTypeMemberPath);
                noticeItem.SetBinding(NoticeItem.NoticeTypeProperty, binding);
            }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new NoticeItem();
        }
        #endregion

        #region Private方法

        #endregion
    }
}

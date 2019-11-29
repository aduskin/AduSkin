using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{ 
    public class NoticeItem : ContentControl
    {
        #region Private属性
        private Button PART_CloseButton;
        #endregion

        #region 依赖属性定义
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty NoticeTypeProperty;
        #endregion

        #region 依赖属性set get
        /// <summary>
        /// 通知标题
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// 通知类型
        /// </summary>
        public EnumNoticeType NoticeType
        {
            get { return (EnumNoticeType)GetValue(NoticeTypeProperty); }
            set { SetValue(NoticeTypeProperty, value); }
        }
        #endregion

        #region Constructors
        static NoticeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NoticeItem), new FrameworkPropertyMetadata(typeof(NoticeItem)));
            NoticeItem.TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(NoticeItem));
            NoticeItem.NoticeTypeProperty = DependencyProperty.Register("NoticeType", typeof(EnumNoticeType), typeof(NoticeItem));
        }
        #endregion

        #region Override方法
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.PART_CloseButton = this.GetTemplateChild("PART_CloseButton") as Button;
            if(this.PART_CloseButton != null)
            {
                this.PART_CloseButton.Click += PART_CloseButton_Click;
            }
        }

        private void PART_CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        ~NoticeItem()
        {
            if (this.PART_CloseButton != null)
            {
                this.PART_CloseButton.Click -= PART_CloseButton_Click;
            }
        }
        #endregion

        #region Private方法

        #endregion
    }

    public enum EnumNoticeType
    {
        /// <summary>
        /// 消息
        /// </summary>
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 失败
        /// </summary>
        Error,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
    }
}

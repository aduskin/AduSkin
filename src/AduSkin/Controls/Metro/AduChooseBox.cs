using AduSkin.Utility.Element;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
   public class AduChooseBox : TextBox
   {
      private Button PART_ChooseButton;

      #region CornerRadius
      public CornerRadius CornerRadius { get { return (CornerRadius)GetValue(CornerRadiusProperty); } set { SetValue(CornerRadiusProperty, value); } }
      public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<AduChooseBox, CornerRadius>("CornerRadiusProperty");
      #endregion

      #region ChooseButtonStyle
      /// <summary>
      /// 获取或者设置选择按钮的样式
      /// </summary>
      public Style ChooseButtonStyle { get { return (Style)GetValue(ChooseButtonStyleProperty); } set { SetValue(ChooseButtonStyleProperty, value); } }
      public static readonly DependencyProperty ChooseButtonStyleProperty = DependencyProperty.Register("ChooseButtonStyle", typeof(Style), typeof(AduChooseBox));
      #endregion

      #region AduChooseBoxType
      public EnumChooseBoxType AduChooseBoxType
      {
         get { return (EnumChooseBoxType)GetValue(AduChooseBoxTypeProperty); }
         set { SetValue(AduChooseBoxTypeProperty, value); }
      }
      public static readonly DependencyProperty AduChooseBoxTypeProperty =
          DependencyProperty.Register("AduChooseBoxType", typeof(EnumChooseBoxType), typeof(AduChooseBox), new PropertyMetadata(EnumChooseBoxType.SingleFile));
      #endregion

      #region ChooseButtonWidth
      public double ChooseButtonWidth
      {
         get { return (double)GetValue(ChooseButtonWidthProperty); }
         set { SetValue(ChooseButtonWidthProperty, value); }
      }
      public static readonly DependencyProperty ChooseButtonWidthProperty =
          DependencyProperty.Register("ChooseButtonWidth", typeof(double), typeof(AduChooseBox), new PropertyMetadata(20d));
      #endregion

      #region ChooseBoxFilter
      public string Filter { get { return (string)GetValue(FilterProperty); } set { SetValue(FilterProperty, value); } }

      public static readonly DependencyProperty FilterProperty =
          DependencyProperty.Register("Filter", typeof(string), typeof(AduChooseBox), new PropertyMetadata("文本文件|*.*"));
      #endregion

      #region DefaultFileName
      public string DefaultFileName
      {
         get { return (string)GetValue(DefaultFileNameProperty); }
         set { SetValue(DefaultFileNameProperty, value); }
      }

      public static readonly DependencyProperty DefaultFileNameProperty =
          DependencyProperty.Register("DefaultFileName", typeof(string), typeof(AduChooseBox), new PropertyMetadata("文件"));
      #endregion

      #region DefaultExt
      public string DefaultExt
      {
         get { return (string)GetValue(DefaultExtProperty); }
         set { SetValue(DefaultExtProperty, value); }
      }

      public static readonly DependencyProperty DefaultExtProperty =
          DependencyProperty.Register("DefaultExt", typeof(string), typeof(AduChooseBox), new PropertyMetadata(""));
      #endregion

      #region Constructors
      static AduChooseBox()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduChooseBox), new FrameworkPropertyMetadata(typeof(AduChooseBox)));
      }
      #endregion

      #region Override
      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();

         this.PART_ChooseButton = this.GetTemplateChild("PART_ChooseButton") as Button;
         if (this.PART_ChooseButton != null)
         {
            this.PART_ChooseButton.Click += PART_ChooseButton_Click;
         }
      }
      #endregion

      #region Event Implement Function
      private void PART_ChooseButton_Click(object sender, RoutedEventArgs e)
      {
         switch (this.AduChooseBoxType)
         {
            case EnumChooseBoxType.SingleFile:
               System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
               openFileDialog.Multiselect = false;
               //"文本文件|*.*|C#文件|*.cs|所有文件|*.*"
               openFileDialog.Filter = this.Filter;
               if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                  this.Text = openFileDialog.FileName;
               break;
            case EnumChooseBoxType.MultiFile:
               break;
            case EnumChooseBoxType.Folder:
               System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
               if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                  this.Text = folderDialog.SelectedPath;
               break;
            case EnumChooseBoxType.SaveFile:
               System.Windows.Forms.SaveFileDialog fileDialog = new System.Windows.Forms.SaveFileDialog();
               fileDialog.Filter = this.Filter;//设置文件类型
               fileDialog.FileName = this.DefaultFileName;//设置默认文件名
               fileDialog.DefaultExt = this.DefaultExt;//设置默认格式（可以不设）
               fileDialog.AddExtension = true;//设置自动在文件名中添加扩展名
               if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                  this.Text = fileDialog.FileName;
               break;
         }
      }
      #endregion
   }
}

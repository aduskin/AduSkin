using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections;
using System.Windows.Input;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace AduSkin.Controls.Metro
{
   /// <summary>
   /// 星级评价控件
   /// </summary>
   public class RatingBar : Control
   {
      #region Private属性
      /// <summary>
      /// 保存评分控件内部的一个个子Item，比如一个个笑脸或者星星
      /// </summary>
      private ObservableCollection<RatingBarButton> RatingButtonsInternal = new ObservableCollection<RatingBarButton>();
      /// <summary>
      /// 该Command在样式xaml中执行
      /// </summary>
      public static RoutedCommand ValueChangedCommand = new RoutedCommand();
      /// <summary>
      /// 用于保存老的分数
      /// 
      /// 鼠标悬浮在控件上时，悬浮在哪个Item上面则预览该分数，如果鼠标没有按下（即没有确认），则当鼠标移开后应该将分数恢复至老的分数
      /// </summary>
      private double mOldValue;
      /// <summary>
      /// 用于保存是否已经选择了一个分数
      /// 
      /// 鼠标悬浮在控件上时，悬浮在哪个Item上面则预览该分数，如果鼠标没有按下（即没有确认），则当鼠标移开后应该将分数恢复至老的分数
      /// </summary>
      private bool mIsConfirm;
      #endregion

      #region 依赖属性定义

      #region Maximum 最大值
      public int Maximum
      {
         get { return (int)GetValue(MaximumProperty); }
         set { SetValue(MaximumProperty, value); }
      }

      public static readonly DependencyProperty MaximumProperty =
          DependencyProperty.Register("Maximum", typeof(int), typeof(RatingBar), new PropertyMetadata(5, MaximumChangedCallback));


      private static void MaximumChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         ((RatingBar)d).CreateRatingButtons();
      }
      #endregion

      #region Minimum 最小值
      public int Minimum
      {
         get { return (int)GetValue(MinimumProperty); }
         set { SetValue(MinimumProperty, value); }
      }

      public static readonly DependencyProperty MinimumProperty =
          DependencyProperty.Register("Minimum", typeof(int), typeof(RatingBar), new PropertyMetadata(1, MinimumChangedCallback, CoreMinimumCallback));

      private static object CoreMinimumCallback(DependencyObject d, object baseValue)
      {
         int value = (int)baseValue;
         if (value < 1)
         {
            return 1;
         }
         return value;
      }

      private static void MinimumChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         ((RatingBar)d).CreateRatingButtons();
      }
      #endregion

      #region Value 当前值
      public double Value
      {
         get { return (double)GetValue(ValueProperty); }
         set { SetValue(ValueProperty, value); }
      }

      public static readonly DependencyProperty ValueProperty =
          DependencyProperty.Register("Value", typeof(double), typeof(RatingBar), new PropertyMetadata(0d, ValueChangedCallback, ValueCoerce));

      private static object ValueCoerce(DependencyObject d, object baseValue)
      {
         RatingBar ratingBar = d as RatingBar;
         double value = 0.0;
         if (double.TryParse(Convert.ToString(baseValue), out value))
         {
            if (value < ratingBar.Minimum)
            {
               value = 0;
            }
            else if (value > ratingBar.Maximum)
            {
               value = ratingBar.Maximum;
            }
         }
         return value;
      }

      private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         RatingBar ratingBar = d as RatingBar;
         double newValue = Convert.ToDouble(e.NewValue);
         var buttonList = ((RatingBar)d).RatingButtonsInternal;

         foreach (var ratingBarButton in buttonList)
         {
            ratingBarButton.IsHalf = false;
            ratingBarButton.IsSelected = ratingBarButton.Value <= newValue;
         }

         //for (int i = 0; i < buttonList.Count; i++)
         //{
         //    RatingBarButton ratingBarButton = buttonList[i];
         //    ratingBarButton.IsSelected = i <= Math.Ceiling(newValue);
         //    ratingBarButton.IsHalf = ratingBar.IsInt(newValue) ? false : Math.Ceiling(newValue) == i;
         //}
      }
      #endregion

      #region ValueItemTemplate
      public DataTemplate ValueItemTemplate
      {
         get { return (DataTemplate)GetValue(ValueItemTemplateProperty); }
         set { SetValue(ValueItemTemplateProperty, value); }
      }

      public static readonly DependencyProperty ValueItemTemplateProperty =
          DependencyProperty.Register("ValueItemTemplate", typeof(DataTemplate), typeof(RatingBar));
      #endregion

      #region ValueItemStyle
      public Style ValueItemStyle
      {
         get { return (Style)GetValue(ValueItemStyleProperty); }
         set { SetValue(ValueItemStyleProperty, value); }
      }

      public static readonly DependencyProperty ValueItemStyleProperty =
          DependencyProperty.Register("ValueItemStyle", typeof(Style), typeof(RatingBar));
      #endregion

      #region SelectedColor 选中的颜色
      public Brush SelectedColor
      {
         get { return (Brush)GetValue(SelectedColorProperty); }
         set { SetValue(SelectedColorProperty, value); }
      }

      public static readonly DependencyProperty SelectedColorProperty =
          DependencyProperty.Register("SelectedColor", typeof(Brush), typeof(RatingBar));
      #endregion

      #region UnSelectedColor 未选中的颜色
      public Brush UnSelectedColor
      {
         get { return (Brush)GetValue(UnSelectedColorProperty); }
         set { SetValue(UnSelectedColorProperty, value); }
      }

      public static readonly DependencyProperty UnSelectedColorProperty =
          DependencyProperty.Register("UnSelectedColor", typeof(Brush), typeof(RatingBar));
      #endregion

      #region IsReadOnly 是否只读
      public bool IsReadOnly
      {
         get { return (bool)GetValue(IsReadOnlyProperty); }
         set { SetValue(IsReadOnlyProperty, value); }
      }

      public static readonly DependencyProperty IsReadOnlyProperty =
          DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(RatingBar), new PropertyMetadata(false));
      #endregion

      #region Content
      public object Content
      {
         get { return (object)GetValue(ContentProperty); }
         set { SetValue(ContentProperty, value); }
      }

      public static readonly DependencyProperty ContentProperty =
          DependencyProperty.Register("Content", typeof(object), typeof(RatingBar));
      #endregion

      #region ContentTemplate
      public DataTemplate ContentTemplate
      {
         get { return (DataTemplate)GetValue(ContentTemplateProperty); }
         set { SetValue(ContentTemplateProperty, value); }
      }

      public static readonly DependencyProperty ContentTemplateProperty =
          DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(RatingBar));
      #endregion

      #region ContentStringFormat
      public string ContentStringFormat
      {
         get { return (string)GetValue(ContentStringFormatProperty); }
         set { SetValue(ContentStringFormatProperty, value); }
      }

      public static readonly DependencyProperty ContentStringFormatProperty =
          DependencyProperty.Register("ContentStringFormat", typeof(string), typeof(RatingBar));
      #endregion

      #region IsShowContent 是否显示内容(最右边的几星几星)
      public bool IsShowContent
      {
         get { return (bool)GetValue(IsShowContentProperty); }
         set { SetValue(IsShowContentProperty, value); }
      }

      public static readonly DependencyProperty IsShowContentProperty =
          DependencyProperty.Register("IsShowContent", typeof(bool), typeof(RatingBar), new PropertyMetadata(true));
      #endregion

      #endregion

      #region 私有依赖属性

      #region RatingButtons
      public IEnumerable RatingButtons
      {
         get { return (IEnumerable)GetValue(RatingButtonsProperty); }
         private set { SetValue(RatingButtonsProperty, value); }
      }

      public static readonly DependencyProperty RatingButtonsProperty =
          DependencyProperty.Register("RatingButtons", typeof(IEnumerable), typeof(RatingBar));
      #endregion

      #endregion

      #region Constructors
      static RatingBar()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(RatingBar), new FrameworkPropertyMetadata(typeof(RatingBar)));
      }

      public RatingBar()
      {
         Utility.Refresh(this);
         CommandBindings.Add(new CommandBinding(ValueChangedCommand, ValueChangedHanlder));
      }

      private void ValueChangedHanlder(object sender, ExecutedRoutedEventArgs e)
      {
         if (!this.IsReadOnly && e.Parameter is int)
         {
            this.Value = Convert.ToDouble(e.Parameter);
            this.mIsConfirm = true;
         }
      }
      #endregion

      #region Override方法
      public override void OnApplyTemplate()
      {
         this.CreateRatingButtons();

         base.OnApplyTemplate();
      }
      #endregion

      #region Private方法
      private void CreateRatingButtons()
      {
         this.RatingButtonsInternal.Clear();
         for (var i = this.Minimum; i <= this.Maximum; i++)
         {
            RatingBarButton button = new RatingBarButton()
            {
               Content = i,
               Value = i,
               IsSelected = i <= Math.Ceiling(this.Value),
               IsHalf = this.IsInt(this.Value) ? false : Math.Ceiling(this.Value) == i,
               ContentTemplate = this.ValueItemTemplate,
               Style = this.ValueItemStyle
            };
            button.ItemMouseEnter += (o, n) =>
            {
               this.mOldValue = this.Value;
               this.Value = button.Value;
               this.mIsConfirm = false;
            };
            button.ItemMouseLeave += (o, n) =>
            {
               if (!this.mIsConfirm)
               {
                  this.Value = this.mOldValue;
                  this.mIsConfirm = false;
               }
            };

            this.RatingButtonsInternal.Add(button);
         }
         this.RatingButtons = this.RatingButtonsInternal;
      }

      private bool IsInt(object value)
      {
         if (Regex.IsMatch(value.ToString(), "^\\d+$"))
         {
            return true;
         }
         else
         {
            return false;
         }
      }
      #endregion
   }
}

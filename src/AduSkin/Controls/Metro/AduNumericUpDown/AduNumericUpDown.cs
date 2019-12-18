using AduSkin.Controls.Helper;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    [TemplatePart(Name = "PART_ContentHost", Type = typeof(ScrollViewer))]
    [TemplatePart(Name = "PART_UP", Type = typeof(Button))]
    [TemplatePart(Name = "PART_DOWN", Type = typeof(Button))]
    public abstract class AduNumericUpDown<T> : AduNumericUpDownBase where T : struct, IComparable
    {
        private Button PART_UP;
        private Button PART_DOWN;

        protected abstract T IncrementValue(T value, T increment);
        protected abstract T DecrementValue(T value, T increment);
        protected abstract T ParseValue(string value);

        #region 事件

        public delegate void UpButtonClickHandler();
        public UpButtonClickHandler UpButtonClick;

        public delegate void DownButtonClickHandler();
        public DownButtonClickHandler DownButtonClick;

        public delegate void ValueChangedHandler(object newValue);
        public ValueChangedHandler ValueChanged;

        #endregion

        #region 依赖属性

        #region Maximum

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum"
            , typeof(T), typeof(AduNumericUpDown<T>), new UIPropertyMetadata(default(T)));

        /// <summary>
        /// 最大值
        /// </summary>
        public T Maximum
        {
            get { return (T)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        private static object OnCoerceMaximum(DependencyObject d, object baseValue)
        {
            AduNumericUpDown<T> AduNumericUpDown = d as AduNumericUpDown<T>;
            if (AduNumericUpDown != null)
            {
                return AduNumericUpDown.OnCoerceMaximum((T)((object)baseValue));
            }
            return baseValue;
        }

        protected virtual T OnCoerceMaximum(T baseValue)
        {
            return baseValue;
        }

        private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Minimum

        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum"
            , typeof(T), typeof(AduNumericUpDown<T>), new UIPropertyMetadata(default(T)));
        /// <summary>
        /// 最小值
        /// </summary>
        public T Minimum
        {
            get { return (T)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        #endregion

        #region Increment

        public static readonly DependencyProperty IncrementProperty = DependencyProperty.Register("Increment"
            , typeof(T), typeof(AduNumericUpDown<T>), new UIPropertyMetadata(default(T)));
        /// <summary>
        /// 增减量
        /// </summary>
        public T Increment
        {
            get { return (T)GetValue(IncrementProperty); }
            set { SetValue(IncrementProperty, value); }
        }

        #endregion

        #region Value

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value"
            , typeof(T), typeof(AduNumericUpDown<T>));
        /// <summary>
        /// 当前值
        /// </summary>
        public T Value
        {
            get { return (T)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        #endregion

        #region IsShowTip

        public static readonly DependencyProperty IsShowTipProperty = DependencyProperty.Register("IsShowTip"
            , typeof(bool), typeof(AduNumericUpDown<T>));
        /// <summary>
        /// 是否显示异常提示
        /// </summary>
        public bool IsShowTip
        {
            get { return (bool)GetValue(IsShowTipProperty); }
            set { SetValue(IsShowTipProperty, value); }
        }

        #endregion

        #region TipText

        public static readonly DependencyProperty TipTextProperty = DependencyProperty.Register("TipText"
            , typeof(string), typeof(AduNumericUpDown<T>));
        /// <summary>
        /// 提示内容
        /// </summary>
        public string TipText
        {
            get { return (string)GetValue(TipTextProperty); }
            set { SetValue(TipTextProperty, value); }
        }

        #endregion

        #region TipBackground

        public static readonly DependencyProperty TipBackgroundProperty = DependencyProperty.Register("TipBackground"
            , typeof(Brush), typeof(AduNumericUpDown<T>), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(252, 110, 81))));
        /// <summary>
        /// 提示内容背景色
        /// </summary>
        public Brush TipBackground
        {
            get { return (Brush)GetValue(TipBackgroundProperty); }
            set { SetValue(TipBackgroundProperty, value); }
        }

        #endregion

        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.PART_UP = VisualHelper.FindVisualElement<Button>(this, "PART_UP");
            this.PART_DOWN = VisualHelper.FindVisualElement<Button>(this, "PART_DOWN");

            if(this.PART_UP != null)
            {
                this.PART_UP.Click += BtnUp_Click;
            }

            if(this.PART_DOWN != null)
            {
                this.PART_DOWN.Click += BtnDown_Click;
            }
            
            this.TextChanged += AduNumericUpDown_TextChanged;
            this.KeyUp += AduNumericUpDown_KeyUp;

            this.SetBtnEnabled(this.Value.ToString());
            this.MoveCursorToEnd();
            this.Value = this.CoreValueCompareMinMax(this.Value);
        }

        private void AduNumericUpDown_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!this.IsFocused) return;

            switch (e.Key)
            {
                case System.Windows.Input.Key.Up:
                    if (this.UpButtonClick != null)
                    {
                        this.UpButtonClick();
                    }
                    break;
                case System.Windows.Input.Key.Down:
                    if (this.DownButtonClick != null)
                    {
                        this.DownButtonClick();
                    }
                    break;
                default:
                    break;
            }
        }

        private void AduNumericUpDown_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(this.IsReadOnly)
            {
                return;
            }

            IsShowTip = false;
            string newValue = ((TextBox)sender).Text;
            EnumCompare type;

            this.Value = this.CoreValueCompareMinMax(this.ParseValue(newValue), out type);
            switch (type)
            {
                case EnumCompare.Less:
                    IsShowTip = true;
                    TipText = string.Format("您输入的数值为{0}，小于最小值{1}", newValue, this.Minimum);
                    break;
                case EnumCompare.Large:
                    IsShowTip = true;
                    TipText = string.Format("您输入的数值为{0}，大于最大值{1}", newValue, this.Maximum);
                    break;
            }

            //if (this.ValueChanged != null)
            //{
            //    ValueChanged(newValue);
            //}
            this.SetBtnEnabled(newValue);
            this.MoveCursorToEnd();
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            //if(this.UpButtonClick != null)
            //{
            //    this.UpButtonClick();
            //}

            T value = this.IncrementValue(this.Value, this.Increment);
            this.Value = this.CoreValueCompareMinMax(value);

            this.MoveCursorToEnd();
        }

        private void BtnDown_Click(object sender, RoutedEventArgs e)
        {
            //if (this.DownButtonClick != null)
            //{
            //    this.DownButtonClick();
            //}

            T value = this.DecrementValue(this.Value, this.Increment);
            this.Value = this.CoreValueCompareMinMax(value);

            this.MoveCursorToEnd();
        }

        private T CoreValueCompareMinMax(T value)
        {
            T result = value;

            if (this.IsLowerThan(value, this.Minimum))
            {
                result = this.Minimum;
            }
            else
            {
                if (this.IsLagerThan(value, this.Maximum))
                {
                    result = this.Maximum;
                }
            }

            return result;
        }

        private T CoreValueCompareMinMax(T value, out EnumCompare type)
        {
            T result = value;
            type = EnumCompare.None;

            if (this.IsLowerThan(value, this.Minimum))
            {
                result = this.Minimum;
                type = EnumCompare.Less;
            }
            else
            {
                if (this.IsLagerThan(value, this.Maximum))
                {
                    result = this.Maximum;
                    type = EnumCompare.Large;
                }
            }

            return result;
        }

        private bool IsLowerThan(T value1, T value2)
        {
            return value1.CompareTo(value2) < 0;
        }

        private bool IsLagerThan(T value1, T value2)
        {
            return value1.CompareTo(value2) > 0;
        }

        private void SetBtnEnabled(string value)
        {
            if (this.PART_UP != null)
            {
                this.PART_UP.IsEnabled = this.Maximum.ToString() != value;
            }
            if (this.PART_DOWN != null)
            {
                this.PART_DOWN.IsEnabled = this.Minimum.ToString() != value;
            }
        }

        /// <summary>
        /// 将光标移动到数字最后面
        /// </summary>
        private void MoveCursorToEnd()
        {
            this.SelectionStart = Convert.ToString(this.Value).Length;
        }
    }
}

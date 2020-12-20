using AduSkin.Controls.Metro;
using AduSkin.Utility.Media;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace AduSkin.Controls
{
   public class Utility
   {
      /// <summary>
      /// 刷新样式
      /// </summary>
      /// <param name="control"></param>
      public static void Refresh(FrameworkElement control)
      {
         if (control == null)
         {
            return;
         }
         //正在运行的状态
         if (!DesignerProperties.GetIsInDesignMode(control))
         {
            if (control.IsLoaded)
            {
               SetColor(control);
            }
            else
            {
               control.Loaded += delegate { SetColor(control); };
            }
         }
      }

      static void SetColor(FrameworkElement control)
      {
         var mw = Window.GetWindow(control) is MetroWindow ? Window.GetWindow(control) as MetroWindow : null;
         if (mw != null)
         {
            if (control is MetroTitleMenu) { (control as MetroTitleMenu).Background = mw.BorderBrush; }
            if (control is MetroMenuItem) { (control as MetroMenuItem).Foreground = mw.BorderBrush; }
            if (control is MetroContextMenu) { (control as MetroContextMenu).Foreground = mw.BorderBrush; }
            if (control is MetroTextBox textbox)
            {
               textbox.BorderBrush = mw.BorderBrush;
               textbox.Foreground = mw.BorderBrush;
            }

            if (control is MetroSwitch) { (control as MetroSwitch).Background = mw.BorderBrush; }
            if (control is MetroButton) { (control as MetroButton).Background = mw.BorderBrush; }
            if (control is MetroMenuTabControl) { (control as MetroMenuTabControl).BorderBrush = mw.BorderBrush; }
            if (control is MetroMenuTabItem) { (control as MetroMenuTabItem).MouseOverColor = mw.BorderBrush; }
            if (control is MetroRichTextBox) { (control as MetroRichTextBox).MouseMoveThemeBorderBrush = mw.BorderBrush; }
            if (control is MetroCanvasGrid) { if ((control as MetroCanvasGrid).IsApplyTheme) (control as MetroCanvasGrid).Background = new RgbaColor(mw.BorderBrush).OpaqueSolidColorBrush; }
            if (control is MetroColorPicker) { (control as MetroColorPicker).BorderBrush = mw.BorderBrush; }

            if (control is ToggleButton) { (control as ToggleButton).Background = mw.BorderBrush; }
            if (control is DataGridRow) { (control as DataGridRow).BorderBrush = mw.BorderBrush; }

            if (control is AduDatePicker)
            {
               var dataPicker = (control as AduDatePicker);
               dataPicker.Foreground = mw.BorderBrush;
               dataPicker.BorderBrush = mw.BorderBrush;
            }
            if (control is AduDIYCheckBox) { (control as AduDIYCheckBox).NormalPathColor = mw.BorderBrush; }
            if (control is AduTimeSelector) { (control as AduTimeSelector).Foreground = mw.BorderBrush; }
            if (control is SegmentItem) { (control as SegmentItem).SelectForeground = mw.BorderBrush; }
            if (control is AduSlider) { (control as AduSlider).Background = mw.BorderBrush; }
            if (control is AduPasswordBox) { (control as AduPasswordBox).BorderBrush = mw.BorderBrush; }
            if (control is AduCheckBox) { (control as AduCheckBox).Foreground = mw.BorderBrush; }
            if (control is AduComboBox) { (control as AduComboBox).Foreground = mw.BorderBrush; }
            if (control is AduComboBox) { (control as AduComboBox).ToggleButtonColor = mw.BorderBrush; }
            if (control is AduRadioButton) { (control as AduRadioButton).Foreground = mw.BorderBrush; }
            if (control is AduTabItem) { (control as AduTabItem).Foreground = mw.BorderBrush; }
            if (control is AduFlatRadionButton) { (control as MetroTitleMenuItem).Foreground = mw.BorderBrush; }
            if (control is AduIndexRadionButton) { (control as AduIndexRadionButton).BorderBrush = mw.BorderBrush; }
            if (control is AduLoading) { (control as AduLoading).Foreground = mw.BorderBrush; }
            if (control is AduTimeButton) { (control as AduTimeButton).Foreground = mw.BorderBrush; }
            if (control is AduFlatSilder) { (control as AduFlatSilder).DecreaseColor = mw.BorderBrush; }
            if (control is AduRadioButtonIcon) { (control as AduRadioButtonIcon).SelectColor = mw.BorderBrush; }
            if (control is AduNumericUpDownBase) { (control as AduNumericUpDownBase).Background = mw.BorderBrush; }
            if (control is AduPathIconButton) { (control as AduPathIconButton).NormalPathColor = mw.BorderBrush; }

            if (control is RatingBar) { (control as RatingBar).SelectedColor = mw.BorderBrush; }
            if (control is AnimationPath) { (control as AnimationPath).Stroke = mw.BorderBrush; }
            //if (control is SegmentControl) { (control as SegmentControl).BorderBrush = (control as SegmentControl).Foreground =  mw.BorderBrush; }

         }
      }
   }
}
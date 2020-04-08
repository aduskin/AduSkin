using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AduSkin.Controls.Helper
{
   internal static class ExtensionMethod
   {
      internal static ImageSource ToImageSource(this Icon icon)
      {
         ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
             icon.Handle,
             Int32Rect.Empty,
             BitmapSizeOptions.FromEmptyOptions());

         return imageSource;
      }

      /// <summary>
      /// Keyboard Accellerators are used in Windows to allow easy shortcuts to controls like Buttons and 
      /// MenuItems. These allow users to press the Alt key, and a shortcut key will be highlighted on the 
      /// control. If the user presses that key, that control will be activated.
      /// This method checks a string if it contains a keyboard accellerator. If it doesn't, it adds one to the
      /// beginning of the string. If there are two strings with the same accellerator, Windows handles it.
      /// The keyboard accellerator character for WPF is underscore (_). It will not be visible.
      /// </summary>
      /// <param name="input"></param>
      /// <returns></returns>
      internal static string TryAddKeyboardAccellerator(this string input)
      {
         const string accellerator = "_";            // This is the default WPF accellerator symbol - used to be & in WinForms

         // If it already contains an accellerator, do nothing
         if (input.Contains(accellerator)) return input;

         return accellerator + input;
      }
   }
}

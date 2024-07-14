using System;
using System.Security;
using System.Windows.Controls;
using System.Windows;

namespace AduSkin.Controls.Helper
{
   public static class BindablePasswordHelper
   {
      public static readonly DependencyProperty BindablePasswordProperty =
          DependencyProperty.RegisterAttached("BindablePassword", typeof(string), typeof(BindablePasswordHelper), new PropertyMetadata(string.Empty, OnBindablePasswordChanged));

      private static readonly DependencyProperty IsUpdatingProperty = DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), typeof(BindablePasswordHelper));

      public static bool GetIsUpdating(DependencyObject obj)
      {
         return (bool)obj.GetValue(IsUpdatingProperty);
      }

      public static void SetIsUpdating(DependencyObject obj, bool value)
      {
         obj.SetValue(IsUpdatingProperty, value);
      }

      public static string GetBindablePassword(DependencyObject dp)
      {
         return (string)dp.GetValue(BindablePasswordProperty);
      }

      public static void SetBindablePassword(DependencyObject dp, string value)
      {
         dp.SetValue(BindablePasswordProperty, value);
      }

      private static void OnBindablePasswordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
      {
         var passwordBox = sender as PasswordBox;
         if (passwordBox == null)
            return;

         // 忽略对BindablePassword属性的更改，从而避免无限循环绑定。
         passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
         var newPassword = (string)e.NewValue;
         if (!GetIsUpdating(passwordBox))
         {
            passwordBox.Password = newPassword;
            SetPasswordLength(passwordBox, passwordBox.Password.Length);
         }
         passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
      }

      private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
      {
         var passwordBox = sender as PasswordBox;
         if (passwordBox == null)
            return;
         SetPasswordLength(passwordBox, passwordBox.Password.Length);
         SetIsUpdating(passwordBox, true);
         SetBindablePassword(passwordBox, passwordBox.Password);
         SetIsUpdating(passwordBox, false);
      }

      public static int GetPasswordLength(DependencyObject obj)
      {
         return (int)obj.GetValue(PasswordLengthProperty);
      }

      public static void SetPasswordLength(DependencyObject obj, int value)
      {
         obj.SetValue(PasswordLengthProperty, value);
      }

      public static readonly DependencyProperty PasswordLengthProperty =
          DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(BindablePasswordHelper), new UIPropertyMetadata(0));


      private static SecureString ConvertToSecureString(string password)
      {
         var securePassword = new SecureString();
         foreach (var c in password)
            securePassword.AppendChar(c);
         securePassword.MakeReadOnly();
         return securePassword;
      }

      private static string ConvertToUnsecureString(SecureString securePassword)
      {
         var unmanagedString = IntPtr.Zero;
         try
         {
            unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
         }
         finally
         {
            System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
         }
      }
   }
}

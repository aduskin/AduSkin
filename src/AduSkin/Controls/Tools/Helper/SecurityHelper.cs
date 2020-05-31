using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace AduSkin.Controls.Tools.Helper
{
   [SuppressMessage("ReSharper", "InconsistentNaming")]
   internal class SecurityHelper
   {
      private static UIPermission _allWindowsUIPermission;

      [SecurityCritical]
      internal static void DemandUIWindowPermission()
      {
         if (_allWindowsUIPermission == null)
         {
            _allWindowsUIPermission = new UIPermission(UIPermissionWindow.AllWindows);
         }
         _allWindowsUIPermission.Demand();
      }
   }
}

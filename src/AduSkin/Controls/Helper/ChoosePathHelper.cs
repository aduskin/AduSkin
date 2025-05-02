
namespace AduSkin.Controls.Helper
{
   public static class ChoosePathHelper
   {
      /// <summary>
      /// ChooseSingleFile
      /// </summary> 
      public static string ChooseSingleFile(string filter = "All File|*.*", bool isMultiselect = false)
      {
         string result = null;
         System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
         openFileDialog.Multiselect = isMultiselect;
         openFileDialog.Filter = filter;
         if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            result = openFileDialog.FileName;
         return result;
      }
      /// <summary>
      /// ChooseSaveFile
      /// </summary> 
      public static string ChooseSaveFile(string filter = "TxtFile|*.*", string defaultFileName = "NewFile", string defaultExt = ".txt")
      {
         string result = null;
         System.Windows.Forms.SaveFileDialog fileDialog = new System.Windows.Forms.SaveFileDialog();
         fileDialog.Filter = filter;
         fileDialog.FileName = defaultFileName;
         fileDialog.DefaultExt = defaultExt;
         fileDialog.AddExtension = true;
         if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            result = fileDialog.FileName;
         return result;
      }
      /// <summary>
      /// ChooseFolder
      /// </summary> 
      public static string ChooseFolder()
      {
         string result = null;
         System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
         if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            result = folderDialog.SelectedPath;
         return result;
      }
   }
}

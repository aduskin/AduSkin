using AduSkin.Controls;

namespace AduSkin.Demo.Models
{
   public class ChatUserModel
   {
      public string SortID { get; set; }

      public int Id { get; set; }

      public string Header { get; set; } = "pack://application:,,,/Resources/Img/Header/头像.png";

      public string UserName { get; set; } = "欢迎使用 AduChat";

      public string Describe { get; set; } = "追求极致，永臻完美";

      public ContactType ContactType { get; set; } = ContactType.Single;

      public bool IsChecked { get; set; }
   }
}

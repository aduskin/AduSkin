
namespace AduSkin.Demo.Models
{
   public class SupportUser
   {
      public SupportUser(string name,string contact,string headerurl,string describe, string[] supportTypes)
      {
         Name = name;
         Contact = contact;
         Header = headerurl;
         Describe = describe;
         SupportTypes = supportTypes;
      }
      public int Id { get; set; }
      //昵称
      public string Name { get; set; }
      //联系方式
      public string Contact { get; set; }
      //头像
      public string Header { get; set; }
      //描述
      public string Describe { get; set; }
      //支持类型
      public string[] SupportTypes { get; set; }
   }
}

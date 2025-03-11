using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AduSkin.Demo.ViewModel
{
   public class FormVerificationDemoViewModel : ObservableValidator, INotifyDataErrorInfo
   {
      private string _Name;
      /// <summary>
      /// 名称
      /// </summary> 
      [Required(ErrorMessage = "请输入用户名.")]
      [MaxLength(30, ErrorMessage = "用户名长度不能大于30.")]
      [MinLength(3, ErrorMessage = "用户名长度不能小于3.")]
      public string Name
      {
         get { return _Name; }
         set
         {
            SetProperty(ref _Name, value, true);
         }
      }

      private int _Age;
      /// <summary>
      /// 年龄
      /// </summary> 
      [Required(ErrorMessage = "请输入年龄.")]
      [Range(0, 120, ErrorMessage = "年龄范围0~120.")]
      public int Age
      {
         get { return _Age; }
         set
         {
            SetProperty(ref _Age, value, true);
         }
      }

      private string _Address;
      /// <summary>
      /// 地址
      /// </summary> 
      [Required(ErrorMessage = "请输入地址.")]
      [MaxLength(30, ErrorMessage = "地址长度不能大于30.")]
      [MinLength(0, ErrorMessage = "地址长度不能小于0.")]
      public string Address
      {
         get { return _Address; }
         set
         {
            SetProperty(ref _Address, value, true);
         }
      }
   }
}

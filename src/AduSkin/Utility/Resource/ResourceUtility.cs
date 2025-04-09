using AduSkin.Controls;
using System;
using System.Reflection;
using System.Windows;

namespace AduSkin.Utility.Resource
{
   public class ResourceUtility
   {
      /// <summary>
      /// 默认控件样式
      /// </summary>
      public static string AduSkin = "pack://application:,,,/AduSkin;component/Themes/AduSkin.xaml";
      /// <summary>
      /// 画刷
      /// </summary>
      public static string Theme = "pack://application:,,,/AduSkin;component/Themes/Theme.xaml";
      /// <summary>
      /// 获取主题颜色
      /// </summary>
      public static string Color = "pack://application:,,,/AduSkin;component/Themes/Colors/{0}.xaml";
      /// <summary>
      /// 控件样式
      /// </summary>
      public static ResourceDictionary GetControlSkin() => new ResourceDictionary() { Source = new Uri(AduSkin, UriKind.Absolute) };
      /// <summary>
      /// 获取主题
      /// </summary> 
      public static ResourceDictionary GetTheme() => new ResourceDictionary() { Source = new Uri(Theme, UriKind.Absolute) };
      /// <summary>
      ///获取自带皮肤
      /// </summary> 
      public static ResourceDictionary GetSkin(SkinType skin) => new ResourceDictionary() { Source = new Uri(string.Format(Color, skin.ToString()), UriKind.Absolute) };
      /// <summary>
      /// 获取其他程序定义的皮肤
      /// </summary>
      public static ResourceDictionary GetSkin(Assembly assembly, string themePath, SkinType skin)
      {
         try
         {
            return new ResourceDictionary { Source = new Uri($"pack://application:,,,/{assembly.GetName().Name};component/{themePath}/{skin}.xaml") };
         }
         catch
         {
            return new ResourceDictionary { Source = new Uri(string.Format(Color, SkinType.Light.ToString()), UriKind.Absolute) };
         }
      }
      
   }
}

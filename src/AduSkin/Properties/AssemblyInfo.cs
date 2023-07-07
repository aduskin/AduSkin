using System.Windows;
using System.Windows.Markup;

[assembly:ThemeInfo(
    ResourceDictionaryLocation.None, //主题特定资源词典所处位置
                             //(当资源未在页面
                             //或应用程序资源字典中找到时使用)
    ResourceDictionaryLocation.SourceAssembly //常规资源词典所处位置
                                      //(当资源未在页面
                                      //、应用程序或任何主题专用资源字典中找到时使用)
)]

//命名空间映射
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Commen")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Attach")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Converter")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Data")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Data.Args")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Expression.Drawing")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Helper")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Metro")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Tools")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Tools.Extension")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Controls.Tools.Interop")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Interactivity")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Utility.AduMethod")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Utility.Computer")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Utility.Element")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Utility.Extend")]
[assembly: XmlnsDefinition("https://github.com/aduskin", "AduSkin.Utility.Media")]
[assembly: XmlnsPrefix("https://github.com/aduskin", "adu")]
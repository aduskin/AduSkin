using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
   public class PlaceHolderAttach
   {
      /// <summary>
      /// 可见
      /// </summary>
      public static readonly DependencyProperty PlaceHolderVisibleProperty = DependencyProperty.RegisterAttached(
            "PlaceHolderVisible", typeof(Visibility), typeof(PlaceHolderAttach), new PropertyMetadata(Visibility.Collapsed));

      public static void SetPlaceHolderVisible(DependencyObject element, Visibility value)
          => element.SetValue(PlaceHolderVisibleProperty, value);

      public static Visibility GetPlaceHolderVisible(DependencyObject element)
          => (Visibility)element.GetValue(PlaceHolderVisibleProperty);

      /// <summary>
      /// 默认占位图标
      /// </summary>
      public static readonly DependencyProperty PathDataProperty = DependencyProperty.RegisterAttached(
          "PathData", typeof(Geometry), typeof(PlaceHolderAttach), new PropertyMetadata(default(Geometry)));

      public static void SetPathData(DependencyObject element, Geometry value)
          => element.SetValue(PathDataProperty, value);

      public static Geometry GetPathData(DependencyObject element)
          => (Geometry)element.GetValue(PathDataProperty);

      /// <summary>
      /// 消息
      /// </summary>
      public static readonly DependencyProperty MessageProperty = DependencyProperty.RegisterAttached(
          "Message", typeof(string), typeof(PlaceHolderAttach), new PropertyMetadata("列表无数据"));

      public static void SetMessage(DependencyObject element, string value)
          => element.SetValue(MessageProperty, value);

      public static string GetMessage(DependencyObject element)
          => (string)element.GetValue(MessageProperty);

      /// <summary>
      /// 加载状态
      /// </summary>
      public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.RegisterAttached(
          "IsLoading", typeof(bool), typeof(PlaceHolderAttach), new PropertyMetadata(default(bool)));

      public static void SetIsLoading(DependencyObject element, bool value)
          => element.SetValue(IsLoadingProperty, value);

      public static bool GetIsLoading(DependencyObject element)
          => (bool)element.GetValue(IsLoadingProperty);

      /// <summary>
      /// 默认加载图标
      /// </summary>
      public static readonly DependencyProperty LoadingPathDataProperty = DependencyProperty.RegisterAttached(
          "LoadingPathData", typeof(Geometry), typeof(PlaceHolderAttach), new PropertyMetadata(default(Geometry)));

      public static void SetLoadingPathData(DependencyObject element, Geometry value)
          => element.SetValue(LoadingPathDataProperty, value);

      public static Geometry GetLoadingPathData(DependencyObject element)
          => (Geometry)element.GetValue(LoadingPathDataProperty);
   }
}

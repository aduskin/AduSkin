using AduSkin.Commen;
using AduSkin.Controls;
using AduSkin.Controls.Data;
using AduSkin.Controls.Helper;
using AduSkin.Utility.Resource;
using System.Windows;
using System.Windows.Media;

namespace AduSkin.Themes
{
   public class AduTheme : ResourceDictionary
   {
      ResourceDictionary AduSkinResourceDictionary = null;
      public AduTheme()
      {
         AduSkinResourceDictionary = ResourceUtility.GetControlSkin();
         //当前样式库需要引用的资源
         Application.Current.Resources.MergedDictionaries.Insert(0, AduSkinResourceDictionary);
      }
      private SkinType _CurrentSkin;
      /// <summary>
      /// 当前主题
      /// </summary>
      public SkinType CurrentSkin
      {
         get { return _CurrentSkin; }
         set
         {
            _CurrentSkin = value;
            UpdateSkin();
         }
      }
      private Color? _AccentColor;
      /// <summary>
      /// 强调色
      /// </summary>
      public Color? AccentColor
      {
         get { return _AccentColor; }
         set
         {
            _AccentColor = value;
            UpdateSkin();
         }
      }
      /// <summary>
      /// 当前主题类型
      /// </summary>
      private SkinType _prevSkinType;
      /// <summary>
      /// 主题资源
      /// </summary>
      private ResourceDictionary _precSkin;
      /// <summary>
      /// 更新主题
      /// </summary>
      private void UpdateSkin()
      {
         //获取主题色
         var newColor = GetSkin(CurrentSkin);
         var theme = Application.Current.Resources.MergedDictionaries[0];
         //获取控件样式
         foreach (var item in theme.MergedDictionaries)
         {
            if (item.MergedDictionaries.Count > 0)
            {
               var oldColor = item.MergedDictionaries[0].MergedDictionaries[0];
               item.MergedDictionaries[0].MergedDictionaries.Remove(oldColor);
               item.MergedDictionaries[0].MergedDictionaries.Insert(0, newColor);
            }
         }
      }
      /// <summary>
      /// 获取皮肤资源
      /// </summary> 
      public virtual ResourceDictionary GetSkin(SkinType skinType)
      {
         if (_precSkin == null || _prevSkinType != skinType)
         {
            _precSkin = ResourceUtility.GetSkin(skinType);
            _prevSkinType = skinType;
         }
         //如果使用主题色
         if (skinType == SkinType.System)
         {
            UnsafeNativeMethods.DwmGetColorizationColor(out var color, out _);
            UpdateAccentColor(ColorHelper.ToColor(color));
         }
         else
         {
            if (AccentColor != null)
               UpdateAccentColor(AccentColor.Value);
         }
         return _precSkin;
      }
      /// <summary>
      /// 设置现有资源的强调色
      /// </summary>
      /// <param name="color"></param>
      private void UpdateAccentColor(Color color)
      {
         _precSkin[ResourceToken.PrimaryColor] = color;
      }
   }
}

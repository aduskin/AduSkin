using System.Collections.Generic;

namespace AduSkin.Controls.Metro
{
    public static class XamlResolver
    {
        private static readonly Dictionary<string, string> XamlByKey = new Dictionary<string, string>();

        public static void Set(string key, string xaml)
        {
            XamlByKey[key] = xaml;
        }

        public static string Resolve(string key)
        {
            if (key != null && XamlByKey.TryGetValue(key, out string xaml))
            {
                return xaml;
            }
            return "";
        }
    }
}
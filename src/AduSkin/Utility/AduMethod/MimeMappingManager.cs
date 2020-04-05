using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;

namespace AduSkin.Utility.AduMethod
{
    public class MimeMappingManager
    {
        public static MimeMappingManager Shared { get; } = new MimeMappingManager();

        public string FallbackMime { get; } = MediaTypeNames.Application.Octet;
        public IDictionary<string, string> MimeMaps { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".jpg", MediaTypeNames.Image.Jpeg },
            { ".jpeg", MediaTypeNames.Image.Jpeg },
            { ".png", "image/png" },
            { ".gif", MediaTypeNames.Image.Gif },
            { ".webp", "image/webp" },
            { ".bmp", "image/bmp" },
            { ".ico", "image/ico" },
            { ".tiff", MediaTypeNames.Image.Tiff },

            { ".txt", MediaTypeNames.Text.Plain },
            { ".html", MediaTypeNames.Text.Html },
            //{ ".rtf", MediaTypeNames.Text.RichText },
            { ".xml", MediaTypeNames.Text.Xml },

            { ".rtf", MediaTypeNames.Application.Rtf },
            { ".json", "application/json" },

        };
        public MimeMappingManager()
        {

        }


        public string GetMimeMapping(string filename)
        {
            if (TryGetMimeMapping(filename, out var mime))
            {
                return mime;
            }
            return FallbackMime;
        }

        public bool TryGetMimeMapping(string filename, out string mimeMapping)
        {
            var extension = Path.GetExtension(filename);
            if (MimeMaps.ContainsKey(extension))
            {
                mimeMapping = MimeMaps[extension];
                return true;
            }
            mimeMapping = FallbackMime;
            return false;
        }
    }
}
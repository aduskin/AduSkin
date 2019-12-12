using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace AduSkin.Controls.Metro
{
    public class XamlFormatter : IXamlFormatter
    {
        //TODO Fully qualify XName
        private static readonly string IgnoredPropertyLocalName =
            $"{nameof(XamlDisplay)}.{XamlDisplay.IgnoreProperty.Name}";

        public string Indent { get; set; } = "    ";
        public bool NewLineOnAttributes { get; set; }
        public bool FormatTextElements { get; set; } = true;
        public bool IncludeIgnoredElements { get; set; }
        public bool FixupIndentation { get; set; } = true;
        public bool RemoveEmptyLines { get; set; } = true;
        public bool RemoveXamlDisplayerDeclaration { get; set; } = true;

        public List<string> NamespacesToRemove { get; } = new List<string>
        {
            "http://schemas.microsoft.com/winfx/2006/xaml/presentation",
            "http://schemas.microsoft.com/winfx/2006/xaml"
        };

        public string FormatXaml(string xaml)
        {
            if (string.IsNullOrWhiteSpace(xaml)) return "";
            const string RemoveName = "XAML_FORMATTER_REMOVE_FROM_DISPLAY";

            try
            {
                var document = XDocument.Parse(xaml);

                if (!IncludeIgnoredElements)
                {
                    foreach (var node in document.DescendantNodes().OfType<XElement>().ToList())
                    {
                        if (node.Name.LocalName.Contains(".") && node.Parent?.Name == RemoveName)
                        {
                            node.Remove();
                            continue;
                        }
                        
                        var ignoreAttribute = node.Attributes().FirstOrDefault(a => a.Name.LocalName == IgnoredPropertyLocalName);
                        switch (ignoreAttribute?.Value)
                        {
                            case nameof(Scope.This):
                                node.Name = RemoveName;
                                node.RemoveAttributes();
                                break;
                            case nameof(Scope.ThisAndChildren):
                                node.Remove();
                                break;
                        }
                    }
                }

                if (RemoveXamlDisplayerDeclaration && document.Root?.Name == XamlDisplay.XmlName)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    document.Root.Name = RemoveName;
                    document.Root.RemoveAttributes();
                }

                if (FormatTextElements)
                {
                    foreach (var textElement in document.DescendantNodes().OfType<XText>())
                    {
                        int indentLevel = CountParents(textElement);
                        textElement.Value = Environment.NewLine +
                                            string.Join("", Enumerable.Repeat(Indent, indentLevel)) +
                                            textElement.Value.Trim() + Environment.NewLine
                            + string.Join("", Enumerable.Repeat(Indent, Math.Max(0, indentLevel - 1)));
                    }
                }
                var sb = new StringBuilder();

                using (var writer = XmlWriter.Create(sb, new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = Indent,
                    NamespaceHandling = NamespaceHandling.OmitDuplicates,
                    NewLineOnAttributes = NewLineOnAttributes,
                    OmitXmlDeclaration = true,
                    NewLineHandling = NewLineHandling.Replace,
                    NewLineChars = Environment.NewLine
                }))
                {
                    document.WriteTo(writer);
                }
                string rv = sb.ToString();

                if (NamespacesToRemove.Any())
                {
                    foreach(var namespaceToRemove in NamespacesToRemove)
                    {
                        rv = Regex.Replace(rv, $@"\s?xmlns(\:\w+)?=\""{Regex.Escape(namespaceToRemove)}\""", "");
                    }
                }

                if (!IncludeIgnoredElements || RemoveXamlDisplayerDeclaration)
                {
                    //TODO: save regex
                    rv = Regex.Replace(rv, $@"</?\s*{RemoveName}\s*>", "");
                }

                if (FixupIndentation)
                {
                    //TODO: Save regex
                    int smallestIndent = Regex.Matches(rv, @"(?<=^|\r?\n)[\s-[\r\n]]*(?=[^\s])", RegexOptions.Multiline).Cast<Match>().Select(m => m.Length).Min();
                    if (smallestIndent > 0)
                    {
                        rv = Regex.Replace(rv, $@"(?<=^|\r?\n)[\s-[\r\n]]{{{smallestIndent}}}", "", RegexOptions.Multiline);
                    }
                }

                if (RemoveEmptyLines)
                {
                    rv = Regex.Replace(rv, @"^\s*\n+", "", RegexOptions.Multiline);
                    rv = rv.Trim();
                }

                return rv;

            }
            catch (Exception)
            {
                return xaml;
            }

            int CountParents(XObject @object)
            {
                int count = 0;
                for (XElement parent = @object.Parent; parent != null; parent = parent.Parent)
                {
                    if (parent.Name.LocalName != RemoveName)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }
}
using System.Reflection;
using System.Text;
using System.Linq;
using System.IO;

namespace PerrysNetConsoleHtml
{
    /// <summary>
    /// Helper to get the default html template out of the dll
    /// </summary>
    internal static class ResourceHelper
    {
        private static string TemplateAssetName { get; } = "Asset.terminal.html";
        private static Encoding TemplateEncoding { get; } = Encoding.UTF8;

        public static string GetDefaultTemplate()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fullResourceName = assembly.GetManifestResourceNames().Single(v => v.EndsWith(TemplateAssetName));

            using (var stream = assembly.GetManifestResourceStream(fullResourceName))
            using (var reader = new StreamReader(stream, TemplateEncoding, false))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

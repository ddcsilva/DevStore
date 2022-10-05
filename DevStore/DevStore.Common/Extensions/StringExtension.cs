using System.Text.RegularExpressions;

namespace DevStore.Common.Extensions
{
    public static class StringExtension
    {
        public static string ToSnakeCase(this string textoOriginal)
        {
            var result = "";

            if (!string.IsNullOrEmpty(textoOriginal))
            {
                var underscoreStart = Regex.Match(textoOriginal, @"^_+");
                result = underscoreStart + Regex.Replace(textoOriginal, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
            }

            return result;
        }
    }
}

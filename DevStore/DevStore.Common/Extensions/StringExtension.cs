using System.Text;
using System.Text.RegularExpressions;

namespace DevStore.Common.Extensions
{
    public static class StringExtension
    {
        public static string ToSnakeCase(this string value)
        {
            var result = "";

            if (!string.IsNullOrEmpty(value))
            {
                var underscoreStart = Regex.Match(value, @"^_+");
                result = underscoreStart + Regex.Replace(value, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
            }

            return result;
        }

        public static string GetSlug(this string value)
        {
            value = value.RemoveAccent().ToLower();
            value = Regex.Replace(value, @"[^a-z0-9\s-]", "");
            value = Regex.Replace(value, @"\s+", " ").Trim();
            value = value.Substring(0, value.Length <= 45 ? value.Length : 45).Trim();
            value = Regex.Replace(value, @"\s", "-");

            return value;
        }

        public static string RemoveAccent(this string value)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}

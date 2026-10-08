using System.Globalization;
using System.Text;

namespace StoreApi.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NormalizedName { get; set; } = string.Empty;

        public static string Normalize(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            var decomposed = name.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);

            var result = new StringBuilder();
            foreach (var c in decomposed)
            {
                var isAccent = CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark;

                if (!isAccent && char.IsLetterOrDigit(c))
                    result.Append(c);
            }

            return result.ToString();
        }
    }
}

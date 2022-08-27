namespace ASMS.CrossCutting.Extensions
{
    public static partial class StringExtensions
    {
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool ContainsIn(this string input, IEnumerable<string> allInputs)
        {
            return allInputs?.Contains(input) ?? false;
        }

        public static bool IsValidGuid(this string value)
        {
            return Guid.TryParse(value, out _);
        }

        public static string TrimSafe(this string input)
        {
            return !string.IsNullOrEmpty(input) ? input.Trim() : string.Empty;
        }

        public static string GetRepositoryName<T>()
        {
            var className = typeof(T).Name;
            return $"{className}Repository";
        }
    }
}

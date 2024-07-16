using System.Reflection;

namespace ASMS.CrossCutting.Extensions
{
    public static partial class StringExtensions
    {
        public static bool IsNullOrEmpty(this string input) => string.IsNullOrEmpty(input);

        public static bool ContainsIn(this string input, IEnumerable<string> allInputs) => allInputs?.Contains(input) ?? false;

        public static bool IsValidGuid(this string value) => Guid.TryParse(value, out _);

        public static string TrimSafe(this string input) => !string.IsNullOrEmpty(input) ? input.Trim() : string.Empty;

        public static bool ItsEqualNormalizedString(this string input, string toCompare) => input.ToLower() == toCompare.ToLower();

        public static string GetRepositoryName<T>()
        {
            var className = typeof(T).Name;
            return $"{className}Repository";
        }

        public static MethodInfo GetStringMethodWithOneStringParameter(string methodName)
        {
            return typeof(string).GetMethod(methodName, new[] { typeof(string) })!;
        }
    }
}

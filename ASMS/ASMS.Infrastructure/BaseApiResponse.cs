using System.Text.Json;

namespace ASMS.Infrastructure
{
    public class BaseApiResponse<TContent>
    {
        public BaseApiResponse()
        {
        }

        public BaseApiResponse(TContent content)
        {
            Success = true;
            Content = content;
        }

        public BaseApiResponse(string error)
        {
            Success = false;
            Errors = $"Error: {error}";
        }

        public BaseApiResponse(IEnumerable<string> errors)
            : this(JsonSerializer.Serialize(errors))
        {
        }

        public bool Success { get; set; }

        public string? Errors { get; set; }

        public TContent? Content { get; set; }
    }
}

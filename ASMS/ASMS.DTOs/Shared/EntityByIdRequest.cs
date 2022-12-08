using System.Text.Json.Serialization;

namespace ASMS.DTOs.Shared
{
    public abstract class EntityByIdRequest<TKey> where TKey : struct
    {
        [JsonIgnore]
        public TKey Id { get; set; }
    }
}

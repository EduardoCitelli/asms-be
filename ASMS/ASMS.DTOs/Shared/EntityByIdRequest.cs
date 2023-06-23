using System.Text.Json.Serialization;

namespace ASMS.DTOs.Shared
{
    public abstract class EntityByIdRequest<TKey> where TKey : struct
    {
        public EntityByIdRequest(TKey id) 
        {
            Id = id;
        }

        [JsonIgnore]
        public TKey Id { get; set; }
    }
}

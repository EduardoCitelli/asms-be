using ASMS.Domain.Abstractions;

namespace ASMS.Domain
{
    public class NameDescriptionEntity<TKey> : AuditEntity<TKey>, INameDescriptionEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
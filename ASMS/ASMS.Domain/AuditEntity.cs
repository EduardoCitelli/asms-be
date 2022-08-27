using ASMS.Domain.Abstractions;

namespace ASMS.Domain
{
    public class AuditEntity<TKey> : BaseEntity<TKey>, IAuditEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string LastEditedBy { get; set; } = string.Empty;

        public bool IsDelete { get; set; }
    }
}

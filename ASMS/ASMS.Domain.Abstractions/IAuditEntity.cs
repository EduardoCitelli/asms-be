namespace ASMS.Domain.Abstractions
{
    public interface IAuditEntity : ISoftDeleteEntity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string LastEditedBy { get; set; }
    }
}
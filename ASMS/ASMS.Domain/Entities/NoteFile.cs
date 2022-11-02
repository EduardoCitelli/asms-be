namespace ASMS.Domain.Entities
{
    public class NoteFile : AuditEntity<long>
    {
        public string UrlPath { get; set; } = string.Empty;

        public virtual InstituteMemberNote InstituteMemberNote { get; set; }
    }
}

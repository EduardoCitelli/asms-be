namespace ASMS.Domain.Entities
{
    public class InstituteMemberNote : NameDescriptionEntity<long>
    {
        public virtual InstituteMember InstituteMember { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual ICollection<NoteFile> NoteFiles { get; set; } = new List<NoteFile>();
    }
}

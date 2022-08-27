namespace ASMS.Domain.Abstractions
{
    public interface ISoftDeleteEntity
    {
        public bool IsDelete { get; set; }
    }
}

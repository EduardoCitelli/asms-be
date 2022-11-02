namespace ASMS.Domain.Abstractions
{
    public interface IIsInstituteEntity : ISoftDeleteEntity
    {
        public long InstituteId { get; }
    }
}

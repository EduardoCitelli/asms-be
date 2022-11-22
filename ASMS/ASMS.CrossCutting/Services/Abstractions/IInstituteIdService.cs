namespace ASMS.CrossCutting.Services.Abstractions
{
    public interface IInstituteIdService
    {
        long InstituteId { get; }

        void SetId(long id);
    }
}
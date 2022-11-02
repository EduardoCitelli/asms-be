namespace ASMS.CrossCutting.Services.Abstractions
{
    public interface IInstituteService
    {
        long InstituteId { get; }

        void SetId(long id);
    }
}
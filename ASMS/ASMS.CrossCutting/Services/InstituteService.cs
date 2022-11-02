using ASMS.CrossCutting.Services.Abstractions;

namespace ASMS.CrossCutting.Services
{
    public class InstituteService : IInstituteService
    {
        public long InstituteId { get; private set; } = 1;

        public void SetId(long id)
        {
            InstituteId = id;
        }
    }
}
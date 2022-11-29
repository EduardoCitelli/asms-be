using ASMS.CrossCutting.Services.Abstractions;

namespace ASMS.CrossCutting.Services
{
    public class InstituteIdService : IInstituteIdService
    {
        public long InstituteId { get; private set; } = 0;

        public void SetId(long id)
        {
            InstituteId = id;
        }
    }
}
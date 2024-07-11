using ASMS.CrossCutting.Services.Abstractions;

namespace ASMS.CrossCutting.Services
{
    public class ClientTimeOffsetService : IClientTimeOffsetService
    {
        public TimeSpan Offset { get; private set; }

        public void SetOffset(int minutesOffset)
        {
            Offset = TimeSpan.FromMinutes(minutesOffset);
        }
    }
}
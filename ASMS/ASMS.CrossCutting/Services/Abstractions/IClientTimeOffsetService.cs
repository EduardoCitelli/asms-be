namespace ASMS.CrossCutting.Services.Abstractions
{
    public interface IClientTimeOffsetService
    {
        TimeSpan Offset { get; }

        void SetOffset(int minutesOffset);
    }
}
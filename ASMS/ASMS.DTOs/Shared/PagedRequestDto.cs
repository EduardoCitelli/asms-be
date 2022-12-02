namespace ASMS.DTOs.Shared
{
    public class PagedRequestDto
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 10;
    }
}
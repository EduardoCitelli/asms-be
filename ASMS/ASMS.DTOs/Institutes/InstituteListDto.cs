namespace ASMS.DTOs.Institutes
{
    public class InstituteListDto : InstituteBasicDto
    {
        public long Id { get; set; }

        public bool IsEnabled { get; set; }
    }
}
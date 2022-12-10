namespace ASMS.DTOs.Shared
{
    public class ComboDto<TKey>
    {
        public TKey Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}

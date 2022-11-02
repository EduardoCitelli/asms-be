namespace ASMS.Domain.Entities
{
    public class Plan : NameDescriptionEntity<int>
    {
        public int AllowedUsers { get; set; }

        public decimal Price { get; set; }

        public bool HasOnlineClasses { get; set; }
    }
}

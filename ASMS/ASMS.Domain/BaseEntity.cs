namespace ASMS.Domain
{
    public abstract class BaseEntity<TKey>
    {
        protected BaseEntity() { }

        protected BaseEntity(TKey id) : this()
        {
            Id = id;
        }

        public virtual TKey Id { get; set; }
    }
}

namespace OrderOut.EF.Models
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset CreatedOn { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTimeOffset ModifiedOn { get; protected set; }
        public string ModifiedBy { get; protected set; }
        public bool IsDeleted { get; protected set; }

    }
}

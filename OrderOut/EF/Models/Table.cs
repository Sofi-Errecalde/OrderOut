namespace OrderOut.EF.Models
{
    public class Table : BaseEntity
    {
        public int AmountPeople { get; set; }
        public int State { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

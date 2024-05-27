namespace OrderOut.EF.Models
{
    public class Table : BaseEntity
    {
        public string Number { get; set; }
        public string status { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}

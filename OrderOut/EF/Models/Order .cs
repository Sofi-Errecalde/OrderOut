namespace OrderOut.EF.Models
{
    public class Order : BaseEntity
    {
        public Table Table { get; set; }

        public DateTime DateTime { get; set; }

        public string Status { get; set; }

        public string PersonName { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

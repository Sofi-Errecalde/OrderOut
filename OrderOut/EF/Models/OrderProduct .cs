namespace OrderOut.EF.Models
{
    public class OrderProduct : BaseEntity
    {
        public Order Order { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string Comment { get; set; }
    }
}

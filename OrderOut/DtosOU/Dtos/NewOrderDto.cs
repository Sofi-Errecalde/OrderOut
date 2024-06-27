namespace OrderOut.DtosOU.Dtos
{
    public class NewOrderDto
    {
        public long TableId { get; set; }

        public DateTime DateTime { get; set; }

        public string Status { get; set; }

        public string? PersonName { get; set; }

        public virtual ICollection<OrderProductDto> OrdersProducts { get; set; }


    }
}

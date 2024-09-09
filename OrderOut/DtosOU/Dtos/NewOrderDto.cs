using OrderOut.Enums;

namespace OrderOut.DtosOU.Dtos
{
    public class NewOrderDto
    {
        public long TableId { get; set; }

        public DateTime Requested { get; set; }
        //public long totalAmount { get; set; }
        public OrderStatusEnum Status { get; set; }

        public long? BillId { get; set; }

        public virtual ICollection<OrderProductDto> OrdersProducts { get; set; }


    }
}

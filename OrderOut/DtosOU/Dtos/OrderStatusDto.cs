using OrderOut.Enums;

namespace OrderOut.DtosOU.Dtos
{
    public class OrderStatusDto
    {  
        public long OrderId {  get; set; }
        public OrderStatusEnum OrderStatus { get; set; }    
    }
}

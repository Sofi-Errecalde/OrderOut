using OrderOut.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOut.EF.Models
{
    public class Order : BaseEntity
    {   
        public DateTime Requested { get; set; }

        public DateTime Delivered { get; set; }

        public long BillId { get; set; }

        public OrderStatusEnum Status { get; set; }


        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }

        public virtual  List<OrderProduct> Products { get; set; }

    }
}

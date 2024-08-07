﻿using OrderOut.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOut.EF.Models
{
    public class Order : BaseEntity
    {   
        public long UserId { get; set; }

        public DateTime DateTime { get; set; }

        public long TableId { get; set; }

        public long BillId { get; set; }

        public OrderStatusEnum Status { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("TableId")]
        public virtual Table Table { get; set; }

        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }

        public virtual  List<OrderProduct> Products { get; set; }

    }
}

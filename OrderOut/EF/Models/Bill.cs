using OrderOut.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOut.EF.Models
{
    public class Bill : BaseEntity
    {   
        public float? Amount { get; set; }
        public float? Tip { get; set; }
        public DateTime Date { get; set; }
        public int WayToPay { get; set; }
        public bool IsPaid { get; set; } = false;
        public long TableWaiterId { get; set; }

        [ForeignKey("TableWaiterId")]
        public virtual TableWaiter TableWaiter { get; set; }

    }
}

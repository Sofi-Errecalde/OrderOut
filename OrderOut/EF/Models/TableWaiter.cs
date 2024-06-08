using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OrderOut.EF.Models
{
    public class TableWaiter:BaseEntity
    {
        [NotNull]
        public long TableId { get; set; }
        [NotNull]
        public long WaiterId {  get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("TableId")]
        public virtual Table Table { get; set; }

        [ForeignKey("WaiterId")]
        public virtual Waiter Waiter { get; set; }
    }
}

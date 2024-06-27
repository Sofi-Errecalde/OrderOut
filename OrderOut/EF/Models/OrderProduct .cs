using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OrderOut.EF.Models
{
    public class OrderProduct : BaseEntity
    {
        [NotNull]
        public int quantity {  get; set; }
        [NotNull]
        public long ProductId { get; set; }
        [ForeignKey("OrderId")]
        public long OrderId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}

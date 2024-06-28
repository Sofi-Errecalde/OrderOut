using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OrderOut.EF.Models
{
    public class OrderProduct : BaseEntity
    {
        
        [NotNull]
        public long ProductId { get; set; }

        [NotNull]
        public int Quantity { get; set; }

        public string Clarification { get; set; }

        [ForeignKey("OrderId")]
        public long OrderId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}

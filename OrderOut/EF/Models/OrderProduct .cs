using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOut.EF.Models
{
    public class OrderProduct : BaseEntity
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}

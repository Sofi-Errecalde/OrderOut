using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOut.EF.Models
{
    public class Order : BaseEntity
    {   
        public long TableId { get; set; }

        public DateTime DateTime { get; set; }

        public string Status { get; set; }

        public string PersonName { get; set; }

        [ForeignKey("TableId")]
        public virtual Table Table { get; set; }

    }
}

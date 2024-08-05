using OrderOut.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOut.EF.Models
{
    public class Bill : BaseEntity
    {   
        public float? Amount { get; set; }
        public float? Tip { get; set; }
        public DateTime Date { get; set; }
        public WayToPayEnum WayToPay { get; set; }
        public string ClientEmail { get; set; }

    }
}

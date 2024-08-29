using OrderOut.EF.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOut.DtosOU.Dtos
{
    public class BillDto
    {
        public float? Amount { get; set; }
        public float? Tip { get; set; }
        public DateTime Date { get; set; }
        public int WayToPay { get; set; }
        public bool IsPaid { get; set; } = false;
        public  TableWaiter TableWaiter { get; set; }
    }
}

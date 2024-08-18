using OrderOut.Enums;

namespace OrderOut.DtosOU
{
    public class RankingWayToPayDto
    {   
        public WayToPayEnum WayToPay { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
    }
}

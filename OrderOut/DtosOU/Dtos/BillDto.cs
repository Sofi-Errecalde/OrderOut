using OrderOut.EF.Models;

namespace OrderOut.DtosOU.Dtos
{
    public class BillDto
    {
        public List<Bill> Bills { get; set; }
        public IndicatorsDto Indicators { get; set; }
    }
}

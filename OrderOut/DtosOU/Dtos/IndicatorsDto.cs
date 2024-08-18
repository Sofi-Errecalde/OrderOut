namespace OrderOut.DtosOU.Dtos
{
    public class IndicatorsDto
    {
        public float TotalAmount { get; set; }
        public float AverageAmount { get; set; }
        public float TotalTip { get; set; }
        public List<RankingWayToPayDto> rankingWayToPayDtos { get; set; }
    }
}

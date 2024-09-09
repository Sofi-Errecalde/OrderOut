namespace OrderOut.DtosOU.Dtos
{
    public class StatisticsDto
    {
        public IndicatorsDto Indicators { get; set; }

        public List<RankingProductosDto> RankingProducts { get; set; }

        public List<RankingTableDto> RankingTables { get; set; }
        
        public List<RankingWaiterDto> RankingWaiterDtos { get; set; }
    }
}

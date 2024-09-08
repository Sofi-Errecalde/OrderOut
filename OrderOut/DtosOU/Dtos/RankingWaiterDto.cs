namespace OrderOut.DtosOU.Dtos
{
    public class RankingWaiterDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int QuantityBills { get; set; }
        public float AverageSpendingPerAccount { get; set; }
        public float AverageTipPerAccount { get; set; }
    }
}

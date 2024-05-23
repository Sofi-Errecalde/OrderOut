namespace OrderOut.EF.Models
{
    public class TableWaiter:BaseEntity
    {
        public Table Table { get; set; }
        public Waiter Waiter { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

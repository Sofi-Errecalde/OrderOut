using System.Diagnostics.CodeAnalysis;

namespace OrderOut.DtosOU.Dtos
{
    public class TableWaiterDto
    {
        [NotNull]
        public long TableId { get; set; }
        [NotNull]
        public long WaiterId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

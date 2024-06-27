namespace OrderOut.DtosOU.Dtos
{
    public class OrderProductDto
    {
        public long ProductId { get; set; } 
        public int Amount { get; set; }
        public string? Clarification { get; set; }
    }
}

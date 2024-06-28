namespace OrderOut.DtosOU.Dtos
{
    public class OrderProductDto
    {
        public long ProductId { get; set; } 
        public int Quantity { get; set; }
        public string? Clarification { get; set; }
    }
}

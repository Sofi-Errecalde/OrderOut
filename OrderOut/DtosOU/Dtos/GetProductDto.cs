namespace OrderOut.DtosOU.Dtos
{
    public class GetProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] ImageUrl { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}

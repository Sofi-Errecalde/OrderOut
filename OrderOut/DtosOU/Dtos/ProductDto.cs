namespace OrderOut.DtosOU.Dtos
{
    public class ProductDto
    {  
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
        public int Making { get; set; }
        public IFormFile? Photo { get; set; }
        public byte[]? Image { get; set; }
        public bool Hidden { get; set; }

    }
}

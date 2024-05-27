namespace OrderOut.EF.Models
{
    public class Menu : BaseEntity
    {   
        public string Name {  get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}

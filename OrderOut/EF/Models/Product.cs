using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOut.EF.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public long CategoryId { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

    }
}

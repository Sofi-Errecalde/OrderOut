using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOut.Dtos
{
    public class ProductDto
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}

﻿namespace OrderOut.EF.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}

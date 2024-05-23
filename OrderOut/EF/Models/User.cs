﻿namespace OrderOut.EF.Models
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
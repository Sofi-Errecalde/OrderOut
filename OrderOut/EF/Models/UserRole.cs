namespace OrderOut.EF.Models
{
    public class UserRole : BaseEntity
    {
    

        public User User { get; set; }

        public Role Role { get; set; }



    }
}

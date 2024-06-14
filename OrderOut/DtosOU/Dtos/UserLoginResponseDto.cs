using OrderOut.EF.Models;

namespace OrderOut.DtosOU.Dtos
{
    public class UserLoginResponseDto
    {   
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<UserRoleDto> UsersRoles { get; set; }
    }

    public class UserRoleDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}

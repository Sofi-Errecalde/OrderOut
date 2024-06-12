using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Services.role
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRole(int roleId);
        Task<Role> GetRoleByName(string roleName);
        Task<bool> CreateRole(RoleDto request);
        Task<bool> CreateUserRole(UserRole request);
        Task<bool> UpdateRole(Role request);
        Task<bool> DeleteRole(int roleId);
    }
}

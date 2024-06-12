using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();
        Task<Role?> GetRole(int roleId);
        Task<Role?> GetRoleByName(string roleName);
        Task<bool> CreateRole(Role role);
        Task<bool> CreateUserRole(UserRole userRole);
        Task<bool> UpdateRole(Role role);
        Task<bool> DeleteRole(int roleId);
    }
}

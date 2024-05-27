using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();
        Task<Role?> GetRole(int roleId);
        Task<bool> CreateRole(Role role);
        Task<bool> UpdateRole(Role role);
        Task<bool> DeleteRole(int roleId);
    }
}

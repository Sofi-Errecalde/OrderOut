using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Services.role
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRole(int roleId);
        Task<bool> CreateRole(Role request);
        Task<bool> UpdateRole(Role request);
        Task<bool> DeleteRole(int roleId);
    }
}

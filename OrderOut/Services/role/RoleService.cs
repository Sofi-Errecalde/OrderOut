using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderOut.EF.Models;
using OrderOut.Repositorys;

namespace OrderOut.Services.role
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository,
                           IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var roles =  await _roleRepository.GetAllRoles();
            var response = _mapper.Map<List<Role>>(roles);
            return response;
        }

        public async Task<Role> GetRole(int roleId)
        {
            var role = await _roleRepository.GetRole(roleId);
            var response = _mapper.Map<Role>(role);
            return response;
        }

        public async Task<bool> CreateRole(Role request)
        {
            var newRole = _mapper.Map<Role>(request);
            var response = await _roleRepository.CreateRole(newRole);
            return response;
        }

        public async Task<bool> UpdateRole(Role request)
        {
            var role = _mapper.Map<Role>(request);
            var response = await _roleRepository.UpdateRole(role);
            return response;
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            var response = await _roleRepository.DeleteRole(roleId);
            return response;
        }
    }
}

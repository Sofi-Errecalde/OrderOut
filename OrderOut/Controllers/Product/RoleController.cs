﻿using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
using OrderOut.Services.role;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("GetRole")]
        public Role GetRole(int roleId)
        {
            return _roleService.GetRole(roleId);
        }

        [HttpGet]
        [Route("AllRoles")]
        public List<Role> AllRoles()
        {
            return _roleService.GetAllRoles();
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<bool> CreateRole(Role role)
        {
            return await _roleService.CreateRole(role);
        }

        [HttpPut]
        [Route("UpdateRole")]
        public async Task<bool> UpdateRole(Role role)
        {
            return await _roleService.UpdateRole(role);
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<bool> DeleteRole(int roleId)
        {
            return await _roleService.DeleteRole(roleId);
        }
    }
}

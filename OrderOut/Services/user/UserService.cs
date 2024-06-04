using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF.Models;
using OrderOut.Repositorys;
using OrderOut.Services.role;

namespace OrderOut.Services.user
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        public UserService(IUserRepository userRepository, IRoleService roleService, AppDbContext context,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _roleService = roleService;
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var response = _mapper.Map<List<User>>(users);
            return response;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            var response = _mapper.Map<User>(user);
            return response;
        }

        public async Task<bool> CreateUser(User request)
        {
            var newUser = _mapper.Map<User>(request);
            var roleUser = _mapper.Map<Role>(_roleService.GetRole(1));
            // Agregar el rol de "user" al nuevo usuario
            //var userRole = new UserRole(request, roleUser); 
            //_dbContext.UsersRoles.Add(userRole);
   //            await _dbContext.SaveChangesAsync();

            var response = await _userRepository.CreateUser(newUser);
            return response;
        }


        public async Task<bool> UpdateUser(User request)
        {
            var user = _mapper.Map<User>(request);
            var response = await _userRepository.UpdateUser(user);
            return response;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var response = await _userRepository.DeleteUser(userId);
            return response;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderOut.EF.Models;
using OrderOut.Repositorys;

namespace OrderOut.Services.user
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            var response = _mapper.Map<List<User>>(users);
            return response;
        }

        public User GetUser(int userId)
        {
            var user = _userRepository.GetUser(userId);
            var response = _mapper.Map<User>(user);
            return response;
        }

        public async Task<bool> CreateUser(User request)
        {
            var newUser = _mapper.Map<User>(request);
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

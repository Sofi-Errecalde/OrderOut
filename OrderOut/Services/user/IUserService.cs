using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Services.user
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int userId);
        Task<bool> CreateUser(CreateUserDto request);
        Task<LoginResponseDto> Login(LoginRequestDto request);
        Task<bool> UpdateUser(User request);
        Task<bool> DeleteUser(int userId);
    }
}

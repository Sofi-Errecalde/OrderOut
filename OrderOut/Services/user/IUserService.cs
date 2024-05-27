using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Services.user
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUser(int userId);
        Task<bool> CreateUser(User request);
        Task<bool> UpdateUser(User request);
        Task<bool> DeleteUser(int userId);
    }
}

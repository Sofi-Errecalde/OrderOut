using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUser(int userId);
        Task<User?> GetUserByEmail(string userEmail);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int userId);
    }
}

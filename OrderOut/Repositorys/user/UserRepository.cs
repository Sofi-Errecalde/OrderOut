using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUser(int userId)
        {
            return await _context.Users.Where(x => x.Id == userId && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByEmail(string userEmail)
        {
            return null;
         //   return await _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Email == userEmail && !x.IsDeleted);
        }

        public async Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
using OrderOut.Services.user;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<User> GetUser(int userId)
        {
            return await _userService.GetUser(userId);
        }

        [HttpGet]
        [Route("AllUsers")]
        public async Task<List<User>> AllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<bool> CreateUser(User user)
        {
            return await _userService.CreateUser(user);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<bool> UpdateUser(User user)
        {
            return await _userService.UpdateUser(user);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<bool> DeleteUser(int userId)
        {
            return await _userService.DeleteUser(userId);
        }
    }
}

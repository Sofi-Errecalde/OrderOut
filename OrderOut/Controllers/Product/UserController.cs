using Microsoft.AspNetCore.Mvc;
using OrderOut.DtosOU.Dtos;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                var response = await _userService.Login(request);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Respuesta 401 para credenciales incorrectas
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                return StatusCode(500, new { Message = "Ocurrió un error interno", Detail = ex.Message });
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<bool> CreateUser(CreateUserDto user)
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

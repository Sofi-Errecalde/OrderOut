﻿using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF.Models;
using OrderOut.Repositorys;
using OrderOut.Services.role;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OrderOut.DtosOU.Dtos;
using Microsoft.Extensions.Options;
using OrderOut.DtosOU;


namespace OrderOut.Services.user
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly Program _program;
        private readonly IOptions<AuthSettings> _authSettings;
        public UserService(IUserRepository userRepository, IRoleService roleService, AppDbContext context,
                           IMapper mapper, IOptions<AuthSettings> authSettings)
        {
            _userRepository = userRepository;
            _roleService = roleService;
            _mapper = mapper;
            _dbContext = context;
            _authSettings = authSettings;
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

        public async Task<bool> CreateUser(UserDto request)
        {

            var exist = await _userRepository.GetUserByEmail(request.Email);
            if (exist != null)
            {
                return false;
            }
            var newUser = _mapper.Map<User>(request);
            // Hashear la contraseña
            var passwordHasher = new PasswordHasher<User>();           
            string hashedPassword = passwordHasher.HashPassword(newUser, request.Password);
            newUser.PasswordHash = hashedPassword;
            var role = await  _roleService.GetRoleByName("Usuario");
            var userRole = new UserRole();
            userRole.User= newUser;
            userRole.Role = role;
            var response = await _userRepository.CreateUser(newUser);
            var response2 = await _roleService.CreateUserRole(userRole);
            return response;
        }

        public async Task<LoginDto> Login(UserDto request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result != PasswordVerificationResult.Success)
            {
                throw new Exception("Error");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Value.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, request.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(_authSettings.Value.TokenDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            var response = new LoginDto
            {
                AccessToken = tokenString,
                User = user
                
            };

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

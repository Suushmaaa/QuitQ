using System.Threading.Tasks;
using QuitQ.API.DTOs;
using QuitQ.API.Models;
using QuitQ.API.Repositories;
using BCrypt.Net;
using QuitQ_Ecomm.DTOS;
using Microsoft.EntityFrameworkCore;

namespace QuitQ.API.Services
{
    public class AuthService(IUserRepository userRepository, JwtTokenHelper jwtHelper)
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly JwtTokenHelper _jwtHelper = jwtHelper;

        public async Task<string> Register(RegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null) return "Email already registered.";

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            await _userRepository.AddAsync(user);
            return "User Registered Successfully";
        }

        public async Task<string?> Login(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            return _jwtHelper.GenerateToken(user);
        }
    }

    internal class JwtTokenHelper
    {
        internal string GenerateToken(object user)
        {
            throw new NotImplementedException();
        }
    }
}

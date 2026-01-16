using Microsoft.AspNetCore.Mvc;
using StockSphere_DN.Data;
using StockSphere_DN.Models.Entities;
using Microsoft.EntityFrameworkCore;
using StockSphere_DN.Models.DTOs;

namespace StockSphere_DN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 
        public AuthController(ApplicationDbContext context) 
        { 
            _context = context; 
        }
        
        // POST: api/Auth/signup
        [HttpPost("signup")] 
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request) 
        { 
            // Check if email already exists
            if (await _context.UserInfos.AnyAsync(u => u.Email == request.Email)) 
                return BadRequest("Email already registered."); 

            // Hash password with BCrypt 
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password); 
            var userInfo = new UserInfo 
            { 
                UserInfoId = Guid.NewGuid(), 
                Email = request.Email, 
                Role = request.Role ?? "User", 
                UserId = Guid.NewGuid(), // reserve UserId for profile later
                PasswordHash = hashedPassword 
            }; 

            _context.UserInfos.Add(userInfo); 
            await _context.SaveChangesAsync(); 
            return Ok(new { Message = "Signup successful", userInfo.UserId });
        } 
        
        // POST: api/Auth/signin
        [HttpPost("signin")] 
        public async Task<IActionResult> SignIn([FromBody] LoginRequest request) { 
            var user = await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == request.Email); 
            if (user == null) return Unauthorized("Invalid credentials."); 
            // Verify password with BCrypt
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash); 
            if (!isPasswordValid) return Unauthorized("Invalid credentials."); 
            // Normally you’d issue a JWT here
            return Ok(new { Message = "Login successful", user.UserId, user.Role });
        } 
    }
}

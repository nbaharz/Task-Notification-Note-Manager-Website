using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GradProj.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenGenerator _tokenGenerator;
        public UserController(IUserService userService, ITokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPut]
        public IActionResult Update(User user)
        {
            _userService.UpdateAsync(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto loginDto)
        {
            try
            {
                var token = await _userService.AuthUser(loginDto.Email, loginDto.Password);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult SignIn(RegisterDto registerDTO)
        {
            // Kullanıcıyı doğrula
            _userService.RegisterUser(registerDTO);

            // Başarılı giriş durumunda kullanıcı bilgilerini döner
            return Ok(registerDTO);
        }
        [Authorize]
        [HttpPost]
        public IActionResult GetName()
        {
            var userid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = _userService.GetByIdAsync(userid).Result;
            return Ok(new { Name = user.Name });
        }
        [HttpGet("verify")]
        public IActionResult VerifyEmail([FromQuery] string token)
        {
            var email = _tokenGenerator.ValidateVerificationToken(token);
            if (email != null)
            {
                var user = _userService.GetSingleAsync(u => u.Email == email).FirstOrDefault();
                if(user == null)
                    return NotFound(new { message = "User not found." });
                if (user.IsVerified)                    
                    return BadRequest(new { message = "Email is already verified." });
                user.IsVerified = true;
                 _userService.UpdateAsync(user);              
              
                return Ok(new { message = "Email verified successfully.", email });
            }
            else
            {
                return BadRequest(new { message = "Invalid or expired token." });
            }

        }

    }
}


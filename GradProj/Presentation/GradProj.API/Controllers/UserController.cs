using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradProj.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
            
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
        public IActionResult LoginUser(string email, string password ) 
        {
            var check = _userService.AuthUser(email,password);
            if (check == null) {
                return Unauthorized(new { message = "Geçersiz e-posta veya şifre." });
            }
            return Ok(check);           

        }
        [HttpPost]
        public IActionResult SignIn(RegisterDto registerDTO)
        {
            // Kullanıcıyı doğrula
            _userService.RegisterUser(registerDTO);

            // Başarılı giriş durumunda kullanıcı bilgilerini döner
            return Ok(registerDTO);
        }
    }

    }


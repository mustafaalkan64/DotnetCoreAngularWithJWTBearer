using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AspnetCoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AspnetCoreProject.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            try
            {
                IActionResult response = Unauthorized();
                var user = Authenticate(login);

                if (user != null)
                {
                    var tokenString = BuildToken(user);
                    response = Ok(new { token = tokenString });
                }
                else
                {
                    return BadRequest("Kullanıcı Adı ve Şifre Hatalı!");
                }

                return response;
            }
            catch (Exception)
            {
                return BadRequest("Login İşlemi Sırasında Hata! Lütfen Giriş Bilgilerinizi Kontrol Ediniz");
            }

        }

        private string BuildToken(UserModel user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.GivenName, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              claims: claims,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;

            if (login.Username == "admin" && login.Password == "admin")
            {
                user = new UserModel { Name = "Mustafa ALKAN", Email = "mustafa.alkan@gdzelektrik.com.tr" };
            }
            return user;
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class UserModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Birthdate { get; set; }
        }
        // [AllowAnonymous]
        // [HttpPost]
        // public IActionResult RequestToken([FromBody] LoginInputModel request)
        // {
        //     try
        //     {
        //         if (request.UserName == "Admin" && request.Password == "Admin")
        //         {
        //             var claims = new[]
        //             {
        //                 new Claim(ClaimTypes.Name, request.UserName)
        //             };

        //             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
        //             var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //             var token = new JwtSecurityToken(
        //                 issuer: "https://localhost:5000",
        //                 audience: "https://localhost:5000",
        //                 claims: claims,
        //                 expires: DateTime.Now.AddMinutes(30),
        //                 signingCredentials: creds);

        //             return Ok(new
        //             {
        //                 token = new JwtSecurityTokenHandler().WriteToken(token)
        //             });
        //         }

        //         return BadRequest("Could not verify username and password");
        //     }
        //     catch(Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }

        // }
    }
}
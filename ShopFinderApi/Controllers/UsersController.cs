using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopFinderApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TravelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
       private readonly ShopFinderApiContext _db;
       IConfiguration configuration;

       public UsersController(ShopFinderApiContext db, IConfiguration configuration)
        {
            _db = db;
            this.configuration = configuration;
        }


        [AllowAnonymous] 
        [HttpPost("/getToken")]
        public IActionResult GetToken(User user)
        { 
            IActionResult response = Unauthorized();

            User resultUser = _db.Users
                .FirstOrDefault(entity => (entity.UserName == user.UserName && entity.Password == user.Password));

            if(resultUser != null)
            {
                var issuer = configuration["Jwt:Issuer"];
                var audience = configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes
                (configuration["Jwt:Key"]);

                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                );

                var subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                    }
                );

                var expires = DateTime.UtcNow.AddMinutes(60);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                // var stringToken = tokenHandler.WriteToken(token);
                return Ok(jwtToken);
            }
            return response;
        }
       
    }
}


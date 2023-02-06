using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using forum.Data;
using forum.Data.Interface;
using forum.Dtos;
using forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace forum.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserServiceRepository repository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public UserController(IUserServiceRepository repository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        [HttpPost("authenticate")]
        public IActionResult authenticate([FromForm] AuthenticateModel model)
        {
            var user = repository.authenticate(model.username, model.password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.id.ToString()),
                    new Claim(ClaimTypes.Role, user.role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                id = user.id,
                username = user.username,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                role = user.role,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult register([FromForm] RegisterModel model)
        {
            var user = mapper.Map<User>(model);
            try
            {
                repository.create(user, model.password);
                return Ok(new
                {
                    id = user.id,
                    username = user.username,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    email = user.email,
                    role = user.role
                });
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
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
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/auth/")]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceRepository repository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public UserController(IUserServiceRepository repository, IUserRoleRepository userRoleRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.repository = repository;
            this.userRoleRepository = userRoleRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult authenticate([FromForm] AuthenticateModel model)
        {
            var user = repository.authenticate(model.username, model.password);
            var userRole = userRoleRepository.userRoles(user.id);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.secret);
       
            ClaimsIdentity getClaimsIdentity()
            {
                return new ClaimsIdentity( getClaims() );

                Claim[] getClaims()
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.id.ToString()));
                    foreach (var item in userRole)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.role.name));
                    }
                    return claims.ToArray();
                }
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = getClaimsIdentity(),
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
                // roles = user.roles,
                accessToken = tokenString
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
                userRoleRepository.createUserRoles(model.roles, user);
                return Ok(new
                {
                    id = user.id,
                    username = user.username,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    email = user.email,
                    roles = model.roles
                });
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
using AutoMapper;
using forum.Data;
using forum.Dtos;
using forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace forum.Controllers
{
    [Authorize(Roles = "admin, superadmin")]
    [ApiController]
    [Route("api/auth/")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository repository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IMapper mapper;

        public RoleController(IRoleRepository repository, IUserRoleRepository userRoleRepository,IMapper mapper)
        {
            this.repository = repository;
            this.userRoleRepository = userRoleRepository;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult createRole([FromForm] RoleCreateDto roleCreateDto)
        {
            var role = mapper.Map<Role>(roleCreateDto);
            repository.create(role);
            return Ok(role);
        }

        // [AllowAnonymous]
        [HttpGet("{user_id}")]
        public ActionResult<IEnumerable<UserRole>> userRoles(int user_id)
        {
            // var userRole = mapper.Map<UserRole>(userRole);
            // var mappedData = mapper.Map<IEnumerable<UserMenuReadDto>>(userMenuItems);

            var userRole = userRoleRepository.userRoles(user_id);
            return Ok(userRole);
        }
    }
}
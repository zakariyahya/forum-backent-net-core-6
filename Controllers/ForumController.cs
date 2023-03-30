using AutoMapper;
using forum.Data.Interface;
using forum.Data.Interfaces;
using forum.Dtos;
using forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace forum.Controllers
{
    // [Authorize(Roles = "admin, superadmin")]
    [Route("api/forum")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IForumRepository repository;
        private readonly IForumSubscription forumSubsRepository;
        private readonly IMapper mapper;

        public ForumController(IForumRepository repository, IForumSubscription forumSubsRepository,IMapper mapper)
        {
            this.repository = repository;
            this.forumSubsRepository = forumSubsRepository;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<ForumReadDto>> forums()
        {
            var forums = repository.forums();
            var mappedData = mapper.Map<IEnumerable<ForumReadDto>>(forums);
            return Ok(mappedData);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<ForumReadDto> createForum([FromForm] ForumCreateDto model, int user_id)
        {
            var mappedData = mapper.Map<MainForum>(model);
            repository.createForum(mappedData);
            forumSubsRepository.createForumSubs(user_id, mappedData);
            // repository.saveChanges();
            var readDto = mapper.Map<ForumReadDto>(mappedData);
            readDto.user_id = user_id;
            return Ok(readDto);
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public ActionResult<ForumReadDto> updateForum(int id, int user_id, [FromForm] ForumUpdateDto model)
        {
            // List<>
            var forum = repository.forumById(id);
            var mappedData = mapper.Map<MainForum>(model);
            // repository.updateForum(mappedData);
            forumSubsRepository.updateForumSubs(user_id, forum);
            // repository.saveChanges();
            var readDto = mapper.Map<ForumReadDto>(mappedData);
            readDto.user_id = user_id;
            return Ok(readDto);
        }
    }
}
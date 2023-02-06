using AutoMapper;
using forum.Dtos;
using forum.Models;

namespace forum.Profiles
{
    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<Forum, ForumReadDto>();
            CreateMap<ForumCreateDto, Forum>();
            CreateMap<ForumUpdateDto, Forum>();


        }
    }
}
using AutoMapper;
using forum.Dtos;
using forum.Models;

namespace forum.Profiles
{
    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<MainForum, ForumReadDto>();
            CreateMap<ForumCreateDto, MainForum>();
            CreateMap<ForumUpdateDto, MainForum>();


        }
    }
}
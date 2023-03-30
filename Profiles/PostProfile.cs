using AutoMapper;
using forum.Dtos;
using forum.Models;

namespace forum.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostRequest, Post>();



        }
    }
}
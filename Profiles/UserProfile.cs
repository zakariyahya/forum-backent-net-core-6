using AutoMapper;
using forum.Dtos;
using forum.Models;

namespace forum.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterModel, User>();
        }
    }
}
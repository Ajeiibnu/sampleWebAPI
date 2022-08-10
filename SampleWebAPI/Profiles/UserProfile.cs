using AutoMapper;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // ________________U s e r _____________________________//
            CreateMap<User, UserCreateDTO>();
            CreateMap<UserCreateDTO, User>();

            CreateMap<User, UserReadDTO>();
            CreateMap<UserReadDTO, User>();
        }
    }
}

using AutoMapper;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Profiles
{
    public class SwordTypeProfile : Profile
    {
        public SwordTypeProfile()
        {
            // ________________Sword Type _____________________________//

            CreateMap<SwordType, TypeReadDTO>();
            CreateMap<TypeReadDTO, SwordType>();

            CreateMap<SwordType, TypeCreateDTO>();
            CreateMap<TypeCreateDTO, SwordType>();
        }
    }
}

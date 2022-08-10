using AutoMapper;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Profiles
{
    public class SwordProfile : Profile
    {
        public SwordProfile()
        {
            // ________________S w o r d _____________________________//
            CreateMap<Sword, SwordReadDTO>();
            CreateMap<SwordReadDTO, Sword>();

            CreateMap<SwordCreateDTO, Sword>();
            CreateMap<Sword, SwordCreateDTO>();

            CreateMap<Sword, SwordTypeElementDTO>();
            CreateMap<SwordTypeElementDTO, Sword>();

            CreateMap<Sword, SwordWithTypeCreateDTO>();
            CreateMap<SwordWithTypeCreateDTO, Sword>();

            CreateMap<Sword, SwordWithTypeReadDTO>();
            CreateMap<SwordWithTypeReadDTO, Sword>();

            // ________________Sword Element _____________________________//
            CreateMap<SwordElement, SwordAddElementDTO>();
            CreateMap<SwordAddElementDTO, SwordElement>();
        }
    }
}

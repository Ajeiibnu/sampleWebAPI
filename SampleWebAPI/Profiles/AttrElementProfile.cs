using AutoMapper;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Profiles
{
    public class AttrElementProfile : Profile
    {
        public AttrElementProfile()
        {
            // ________________Attribute Element _____________________________//
            CreateMap<AttrElement, AttrElementReadDTO>();
            CreateMap<AttrElementReadDTO, AttrElement>();

            CreateMap<AttrElement, AttrElementCreateDTO>();
            CreateMap<AttrElementCreateDTO, AttrElement>();
        }
    }
}

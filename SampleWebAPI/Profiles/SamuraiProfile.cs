using AutoMapper;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
        {
            // ________________S a m u r a i _____________________________
            CreateMap<SamuraiWithQuotesDTO, Samurai>();
            CreateMap<Samurai, SamuraiWithQuotesDTO>();

            CreateMap<Samurai, SamuraiWithSwordReadDTO>();
            CreateMap<SamuraiWithSwordReadDTO, Samurai>();

            CreateMap<Samurai, SamuraiWithSwordCreateDTO>();
            CreateMap<SamuraiWithSwordCreateDTO, Samurai>();

            CreateMap<Samurai, SamuraiReadDTO>();
            CreateMap<SamuraiReadDTO, Samurai>();
            CreateMap<SamuraiCreateDTO, Samurai>();
        }
    }
}

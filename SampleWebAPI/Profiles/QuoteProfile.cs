using AutoMapper;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Profiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            // ________________Q u o t e _____________________________//
            CreateMap<QuoteDTO, Quote>();
            CreateMap<Quote, QuoteDTO>();
        }
    }
}

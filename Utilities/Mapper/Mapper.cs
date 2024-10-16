using AutoMapper;

namespace apief
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Password, PasswordDto>().ReverseMap();
            CreateMap<Password, PasswordResponsDto>().ReverseMap();
            CreateMap<AdditionalField, AdditionalFieldDto>().ReverseMap();
        }
    }
}
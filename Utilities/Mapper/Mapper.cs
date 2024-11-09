using AutoMapper;

namespace apief
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Password, PasswordDto>().ReverseMap();
            CreateMap<Password, PasswordResponsDto>().ReverseMap();
            CreateMap<Password, PasswordForUpdateDto>().ReverseMap();
            CreateMap<AdditionalField, AdditionalFieldDto>().ReverseMap();
            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<Note, NoteResponseDto>().ReverseMap();
            CreateMap<NoteDto, NoteResponseDto>().ReverseMap();
            CreateMap<NoteUpdateDto, NoteResponseDto>().ReverseMap();
        }
    }
}
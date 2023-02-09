using AutoMapper;
using AutorService.DTOS;
using AutorService.Model;

namespace AutorService.Aplication.Utilities
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<AutorBook, AutorBookDTO>();

        }

    }
}

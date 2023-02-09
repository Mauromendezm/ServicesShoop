using AutoMapper;
using BookService.Aplication.DTOS;
using BookService.Model;

namespace BookService.Aplication.Utilities
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<MaterialLibrary, MaterialLibraryDTO>();
        }
    }
}

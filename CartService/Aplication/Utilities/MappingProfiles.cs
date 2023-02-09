using AutoMapper;
using CartService.Aplication.DTOS;
using CartService.RemoteModel;

namespace CartService.Aplication.Utilities
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<AutorRemote, AutorDTO>();

        }

    }
}

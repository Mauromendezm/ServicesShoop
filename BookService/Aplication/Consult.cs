using AutoMapper;
using BookService.Aplication.DTOS;
using BookService.Model;
using BookService.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookService.Aplication
{
    public class Consult
    {
        public class Execute : IRequest<List<MaterialLibraryDTO>>
        {

        }

        public class Handler : IRequestHandler<Execute, List<MaterialLibraryDTO>>
        {
            private readonly LibreryContext _libreryContext;
            private readonly IMapper _mapper;

            public Handler(LibreryContext libreryContext, IMapper mapper)
            {
                this._libreryContext = libreryContext;
                this._mapper = mapper;
            }
            public async Task<List<MaterialLibraryDTO>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await _libreryContext.MaterialLibrary.ToListAsync();

                var booksDTO = _mapper.Map<List<MaterialLibrary>, List<MaterialLibraryDTO>>(books);

                return booksDTO;
            }
        }
    }

}

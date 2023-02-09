using AutoMapper;
using BookService.Aplication.DTOS;
using BookService.Model;
using BookService.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookService.Aplication
{
    public class ConsultFilter
    {
        public class Execute : IRequest<MaterialLibraryDTO>
        {
            public Guid? MaterialLibreryId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, MaterialLibraryDTO>
        {
            private readonly LibreryContext _libreryContext;
            private readonly IMapper _mapper;

            public Handler(LibreryContext libreryContext, IMapper mapper)
            {
                this._libreryContext = libreryContext;
                this._mapper = mapper;
            }
            public async Task<MaterialLibraryDTO> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = await _libreryContext.MaterialLibrary.Where(a => a.MaterialLibreryId == request.MaterialLibreryId).FirstOrDefaultAsync();

                var bookDTO = _mapper.Map<MaterialLibrary, MaterialLibraryDTO>(book);

                if (book == null)
                {
                    throw new System.Exception("No se encontro el libro");
                }

                return bookDTO;
            }
        }
    }
}

using AutoMapper;
using AutorService.DTOS;
using AutorService.Model;
using AutorService.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutorService.Aplication
{
    public class ConsultFilter
    {
        public class UnicAutor: IRequest<AutorBookDTO>
        {
            public string AutorGuid { get; set; }
        }

        public class Handler : IRequestHandler<UnicAutor, AutorBookDTO>
        {
            private readonly AutorContext _autorContext;
            private readonly IMapper _mapper;

            public Handler(AutorContext autorContext, IMapper mapper)
            {
                this._autorContext = autorContext;
                this._mapper = mapper;
            }
            public async Task<AutorBookDTO> Handle(UnicAutor request, CancellationToken cancellationToken)
            {
                var autor = await _autorContext.AutorBook.Where(a => a.AutorBookGuid == request.AutorGuid.Trim()).FirstOrDefaultAsync();

                var autorDTO = _mapper.Map<AutorBook, AutorBookDTO>(autor);

                if (autor == null)
                {
                    throw new System.Exception("No se encontro eñ autor");
                }

                return autorDTO;
            }
        }
    }
}

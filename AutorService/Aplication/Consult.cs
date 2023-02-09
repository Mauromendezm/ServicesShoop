using AutoMapper;
using AutorService.DTOS;
using AutorService.Model;
using AutorService.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutorService.Aplication
{
    public class Consult
    {
        public class ListAutors: IRequest<List<AutorBookDTO>>
        {

        }

        public class Handler : IRequestHandler<ListAutors, List<AutorBookDTO>>
        {
            private readonly AutorContext _autorContext;
            private readonly IMapper _mapper;

            public Handler(AutorContext autorContext, IMapper mapper)
            {
                this._autorContext = autorContext;
                this._mapper = mapper;
            }
            public async Task<List<AutorBookDTO>> Handle(ListAutors request, CancellationToken cancellationToken)
            {
                var autors = await _autorContext.AutorBook.ToListAsync();

                var autorsDTO = _mapper.Map<List<AutorBook>, List<AutorBookDTO>>(autors);

                return autorsDTO;
            }
        }
    }
}

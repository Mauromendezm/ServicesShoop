using AutoMapper;
using CartService.Aplication.DTOS;
using CartService.Model;
using CartService.Persistence;
using CartService.RemoteInterface;
using CartService.RemoteModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CartService.Aplication
{
    public class Consult
    {
        public class Execute : IRequest<CartDTO>
        {
            public int SessionCarId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, CartDTO>
        {
            private readonly CartContext _cartContext;
            private readonly IBookService _bookService;
            private readonly IAutorService _autorService;
            private readonly IMapper _mapper;

            public Handler(CartContext cartContext,
                            IBookService bookService,
                            IAutorService autorService,
                            IMapper mapper)
            {
                this._cartContext = cartContext;
                this._bookService = bookService;
                this._autorService = autorService;
                this._mapper = mapper;
            }

            public async Task<CartDTO> Handle(Execute request, CancellationToken cancellationToken)
            {
                SessionCart sessionCart = await _cartContext.SessionCart.FirstOrDefaultAsync(x => x.SessionCartId == request.SessionCarId);
                if (sessionCart is null)
                {
                    return new CartDTO();
                }

                var sessionCartDetail = await _cartContext.SessionCartDetail.Where(x => x.SessionCartId == request.SessionCarId).ToListAsync();

                if (sessionCartDetail is null)
                {
                    return new CartDTO()
                    {
                        CartId = sessionCart.SessionCartId,
                        CreatedDateSession = sessionCart.CreatedDate,
                        LIstDetail = new List<SessionCartDTO>()
                    };
                }

                List<SessionCartDTO> sessionCartDetailList = new List<SessionCartDTO>();
                foreach (var book in sessionCartDetail)
                {
                    var response = await _bookService.GetLibro(new Guid(book.Product));

                    if (!response.result)
                    {
                        continue;
                    }
                    BookRemote objBook = response.book;

                    var responseAutor = await _autorService.GetAutor(objBook.AutorBook.ToString());
                    if (!responseAutor.result)
                    {
                        continue;
                    }
                    AutorRemote objAutor = responseAutor.autor;

                    var cartDetail = new SessionCartDTO
                    {
                        TitleBook = objBook.Title,
                        PublicationDate = objBook.PublicationDate,
                        LibroId = objBook.MaterialLibreryId,
                        AutorBook = _mapper.Map<AutorDTO>(objAutor)
                    };
                    sessionCartDetailList.Add(cartDetail);
                }

                CartDTO cart = new CartDTO
                {
                    CartId = sessionCart.SessionCartId,
                    CreatedDateSession = sessionCart.CreatedDate,
                    LIstDetail = sessionCartDetailList
                };

                return cart;
            }
        }
    }
}

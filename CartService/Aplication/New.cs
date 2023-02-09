using CartService.Model;
using CartService.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CartService.Aplication
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime CreatedDate { get; set; }
            public List<string> ListProduct { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly CartContext _cartContext;

            public Handler(CartContext cartContext)
            {
                this._cartContext = cartContext;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var sessionCart = new SessionCart
                {
                    CreatedDate = request.CreatedDate,
                };

                _cartContext.SessionCart.Add(sessionCart);
                var value1 = await _cartContext.SaveChangesAsync();

                if (value1 == 0)
                {
                    throw new Exception("Error en isnesión de carro");
                }

                int id = sessionCart.SessionCartId;

                foreach (var item in request.ListProduct)
                {
                    var detailSession = new SessionCartDetail
                    {
                        CreatedDate = DateTime.Now,
                        SessionCartId = id,
                        Product = item
                    };

                    _cartContext.SessionCartDetail.Add(detailSession);
                }
                value1 = await _cartContext.SaveChangesAsync();

                if (value1 == 0)
                {
                    throw new Exception("Error en isnesión de carro");
                }

                return Unit.Value;

            }
        }
    }
}

using CartService.Aplication;
using CartService.Aplication.DTOS;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CartService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("{cartId}")]
        public async Task<ActionResult<CartDTO>> getCarrito(int cartId)
        {
            return await _mediator.Send(new Consult.Execute {SessionCarId = cartId});
        }
    }
}

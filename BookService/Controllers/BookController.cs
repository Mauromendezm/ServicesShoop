using BookService.Aplication;
using BookService.Aplication.DTOS;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> New(New.Execute request)
        {
            return await _mediator.Send(request);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<MaterialLibraryDTO>>> Books()
        {
            return await _mediator.Send(new Consult.Execute());
        }

        [HttpGet("{idBook}")]
        public async Task<ActionResult<MaterialLibraryDTO>> GetAutor(Guid idBook)
        {
            return await _mediator.Send(new ConsultFilter.Execute { MaterialLibreryId = idBook });
        }
    }
}

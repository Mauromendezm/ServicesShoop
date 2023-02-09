using AutorService.Aplication;
using AutorService.DTOS;
using AutorService.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutorService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute request)
        {
            return await _mediator.Send(request);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<AutorBookDTO>>> GetAutors()
        {
            return await _mediator.Send(new Consult.ListAutors());
        }
        
        [HttpGet("{idAutor}")]
        public async Task<ActionResult<AutorBookDTO>> GetAutor(string idAutor)
        {
            return await _mediator.Send(new ConsultFilter.UnicAutor { AutorGuid = idAutor});
        }
    }
}

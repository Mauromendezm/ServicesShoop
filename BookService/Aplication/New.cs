using BookService.Model;
using BookService.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookService.Aplication
{
    public class New
    {
        public class Execute: IRequest
        {
            public string Title { get; set; }
            public DateTime? PublicationDate { get; set; }
            public Guid? AutorBook { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(c => c.Title).NotEmpty();
                RuleFor(c => c.PublicationDate).NotEmpty();
                RuleFor(c => c.AutorBook).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly LibreryContext _libreryContext;

            public Handler(LibreryContext libreryContext)
            {
                this._libreryContext = libreryContext;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var newItem = new MaterialLibrary
                {
                    Title = request.Title,
                    PublicationDate = request.PublicationDate,
                    AutorBook = request.AutorBook
                };

                _libreryContext.MaterialLibrary.Add(newItem);
                var response = await _libreryContext.SaveChangesAsync();

                if (response == 0)
                {
                    throw new Exception("No se pudo insertar");
                }

                return Unit.Value;
            }
        }
    }
}

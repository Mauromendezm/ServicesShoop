using AutorService.Model;
using AutorService.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutorService.Aplication
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Name { get; set; }
            public string Lastname { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Lastname).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly AutorContext _autorContext;

            public Handler(AutorContext autorContext)
            {
                this._autorContext = autorContext;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var autorBook = new AutorBook
                {
                    Name = request.Name,
                    Lastname = request.Lastname,
                    BirthDate = request.BirthDate,
                    AutorBookGuid = Guid.NewGuid().ToString()
                };

                _autorContext.AutorBook.Add(autorBook);
                var response = await _autorContext.SaveChangesAsync();

                if (response == 0)
                {
                    throw new Exception("No se inserto el autor de libro.");
                }

                return Unit.Value;

            }
        }
    }
}

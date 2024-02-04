using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeadApplication.Domain.Commands.CreateTeste
{
    public class CreateTesteCommandHandler : IRequestHandler<CreateTesteCommand, string>
    {

        private readonly IMediator _mediator;

        public CreateTesteCommandHandler(
                IMediator mediator
        )
        {
            _mediator = mediator;

        }

        public async Task<string> Handle(CreateTesteCommand command, CancellationToken cancellationToken)
        {
            return command.Name;
        }


    }
}

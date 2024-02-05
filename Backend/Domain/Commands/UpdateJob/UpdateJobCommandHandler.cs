using LeadApplication.Domain.Enums;
using LeadApplication.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeadApplication.Domain.Commands.CreateTeste
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, bool>
    {
        private readonly IJobService _jobService;

        private readonly IMediator _mediator;

        public UpdateJobCommandHandler(
                IMediator mediator,
                IJobService jobService
        )
        {
            _mediator = mediator;
            _jobService = jobService;
        }

        public async Task<bool> Handle(UpdateJobCommand command, CancellationToken cancellationToken)
        {
            var job = await _jobService.GetById(command.Id);

            if (job == null)
            {
                return false;
            }

            if (command.Approved)
            {
                await _jobService.AcceptJob(job);
            }
            else
            {
                await _jobService.DeclineJob(job);
            }

            return true;
        }


    }
}

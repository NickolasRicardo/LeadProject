using Domain.Entities;
using LeadApplication.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeadApplication.Domain.Query.ListTeste
{
    public class ListJobQueryHandler : IRequestHandler<ListJobsQuery, ListJobsQueryResponse>
    {

        private readonly IMediator _mediator;
        private readonly IJobService _jobService;
        public ListJobQueryHandler(
                IMediator mediator,
                IJobService jobService
        )
        {
            _mediator = mediator;
            _jobService = jobService;
        }

        public async Task<ListJobsQueryResponse> Handle(ListJobsQuery query, CancellationToken cancellationToken)
        {

            var ListJobs = await _jobService.GetByStatus(query.status);

            var response = new ListJobsQueryResponse().MapToResponse(ListJobs);

            return response;
        }


    }
}

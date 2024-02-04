using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeadApplication.Domain.Query.ListTeste
{
    public class ListTesteQueryHandler : IRequestHandler<ListTesteQuery, string>
    {

        private readonly IMediator _mediator;

        public ListTesteQueryHandler(
                IMediator mediator
        )
        {
            _mediator = mediator;

        }

        public async Task<string> Handle(ListTesteQuery query, CancellationToken cancellationToken)
        {
            return query.Name;
        }


    }
}

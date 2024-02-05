using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeadApplication.Domain.Commands.CreateTeste
{
    public class UpdateJobCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
    }
}

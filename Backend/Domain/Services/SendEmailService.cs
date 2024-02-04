using Domain.Entities;
using LeadApplication.Domain.Enums;
using LeadApplication.Domain.Interfaces.Repositories;
using LeadApplication.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IJobRepository _repository;

        public SendEmailService(IJobRepository repository)
        {
            _repository = repository;
        }
        

        public async Task SendEmail()
        {
            throw new NotImplementedException();
        }
    }
}

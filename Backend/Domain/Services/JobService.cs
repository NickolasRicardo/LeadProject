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
    public class JobService : IJobService
    {
        private readonly IJobRepository _repository;
        private readonly ISendEmailService _sendEmailService;

        public JobService(IJobRepository repository, ISendEmailService sendEmailService)
        {
            _repository = repository;
            _sendEmailService = sendEmailService;
        }

        public async Task Add(JobEntity entity)
        {
            await _repository.Add(entity);
        }

        public async Task Update(JobEntity entity)
        {
            await _repository.Update(entity);
        }

        public async Task DeclineJob(JobEntity entity)
        {
            entity.Status = JobStatus.Negado;
            await _repository.Update(entity);
        }

        public async Task AcceptJob(JobEntity entity)
        {
            entity.Status = JobStatus.Aprovado;
            
            if(entity.Price > 500)
            {
                entity.Price *= 0.9;
            }

            await _repository.Update(entity);
            _ = _sendEmailService.SendEmail();
        }

        public async Task<JobEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<JobEntity>> GetByStatus(int status)
        {
            return await _repository.GetByStatus(status);
        }
    }
}

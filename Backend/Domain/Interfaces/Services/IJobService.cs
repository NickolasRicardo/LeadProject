using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadApplication.Domain.Interfaces.Services
{
    public interface IJobService
    {
        Task Add(JobEntity entity);
        Task Update(JobEntity entity);
        Task DeclineJob(JobEntity entity);
        Task AcceptJob(JobEntity entity);

        Task<JobEntity> GetById(int id);
        Task<List<JobEntity>> GetByStatus(int status);
    }
}

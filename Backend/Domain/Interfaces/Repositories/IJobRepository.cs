using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadApplication.Domain.Interfaces.Repositories
{
    public interface IJobRepository
    {
        Task Add(JobEntity item);
        Task Update(JobEntity item);
        Task Delete(int id);
        Task<JobEntity> GetById(int id);
        Task<List<JobEntity>> GetAll();
        Task<List<JobEntity>> GetByStatus(int status);

    }
}

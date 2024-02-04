using Domain.Entities;
using LeadApplication.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace LeadApplication.Infrastructure.Database.Repository
{
    public class JobRepository : IJobRepository
    {
        private DatabaseContext _context;
        public JobRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(JobEntity entity)
        {
            _context.Job.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(JobEntity entity)
        {
            _context.Job.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<JobEntity> GetById(int id)
        {
            return await _context.Job.Include(j=> j.Client).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Job.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<JobEntity>> GetAll()
        {
            return await _context.Job.ToListAsync();
        }

        public async Task<List<JobEntity>> GetByStatus(int status)
        {
            return await _context.Job.Where(j=> (int) j.Status == status ).ToListAsync();
        }

    }
}

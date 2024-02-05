using Domain.Entities;
using LeadApplication.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace LeadApplication.Infrastructure.Database.Repository
{
    public class ClientRepository : IClientRepository
    {
        private DatabaseContext _context;
        public ClientRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(ClientEntity entity)
        {
            _context.Client.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ClientEntity entity)
        {
            _context.Client.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientEntity> GetById(int id)
        {
            return await _context.Client.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Client.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

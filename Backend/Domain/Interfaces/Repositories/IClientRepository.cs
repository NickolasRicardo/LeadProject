using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadApplication.Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task Add(ClientEntity item);
        Task Update(ClientEntity item);
        Task Delete(int id);
        Task<ClientEntity> GetById(int id);
    }
}

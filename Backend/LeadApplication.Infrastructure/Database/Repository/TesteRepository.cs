using LeadApplication.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadApplication.Infrastructure.Database.Repository
{
    public class TesteRepository : ITesteRepository
    {
        private DatabaseContext _context;
        public TesteRepository(DatabaseContext context)
        {
            _context = context;
        }

    }
}

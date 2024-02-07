using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadApplication.Infrastructure.Seed
{
    public static class DatabaseSeed
    {
        public static void Seed(Database.DatabaseContext context)
        {
            if (!context.Client.Any())
            {
                var clientJoao = new ClientEntity()
                {
                    Name = "João Melo",
                    Email = "joao@gmail.com",
                    PhoneNumber = "12123451234",
                    Suburb = "5393 Xavier Marginal - Piquete, AL",
                };

                var clientJose = new ClientEntity()
                {
                    Name = "José Alcantara",
                    Email = "jose@gmail.com",
                    PhoneNumber = "12567895678",
                    Suburb = "87994 Tertuliano Marginal - Igaratinga, SE",
                };

                var clientFernanda = new ClientEntity()
                {
                    Name = "Fernanda Amaral",
                    Email = "fernanda@gmail.com",
                    PhoneNumber = "12123456789",
                    Suburb = "867 Fábio Rodovia - Viradouro, CE",
                };

                context.Client.AddRange(new List<ClientEntity>()
                {
                    clientJoao,
                    clientJose,
                    clientFernanda
                });

                var Job1 = new JobEntity()
                {
                    Category = Domain.Enums.JobCategory.InteriorPainters,
                    Client = clientJoao,
                    ClientId = clientJoao.Id,
                    Price = 300,
                    Status = Domain.Enums.JobStatus.Pendente,
                    CreatedAt = DateTime.Now,
                    Description = "I am looking for a professional painting service to renovate my dining room. I would like to transform the space, giving it a fresh and inviting appearance.",
                };

                var Job2 = new JobEntity()
                {
                    Category = Domain.Enums.JobCategory.Painters,
                    Client = clientJoao,
                    ClientId = clientJoao.Id,
                    Price = 1000,
                    Status = Domain.Enums.JobStatus.Pendente,
                    CreatedAt = DateTime.Now,
                    Description = "I am in need of a professional exterior painting service to revitalize the exterior of my home. I aim to enhance the curb appeal, giving it a fresh and welcoming look.",
                };

                var Job3 = new JobEntity()
                {
                    Category = Domain.Enums.JobCategory.HomeRenovations,
                    Client = clientJose,
                    ClientId = clientJose.Id,
                    Price = 9000,
                    Status = Domain.Enums.JobStatus.Aprovado,
                    CreatedAt = DateTime.Now,
                    Description = "I am seeking a professional renovation service to revamp my home. I aim to enhance its overall appearance and functionality, creating a space that feels refreshed and inviting.",
                };

                var Job4 = new JobEntity()
                {
                    Category = Domain.Enums.JobCategory.GeneralBuildingWork,
                    Client = clientJose,
                    ClientId = clientJose.Id,
                    Price = 30,
                    Status = Domain.Enums.JobStatus.Negado,
                    CreatedAt = DateTime.Now,
                    Description = "I'm seeking a professional service to replace the faucet in my kitchen/bathroom. I need a quick and efficient replacement to fix leaks and improve the water system's functionality.",
                };

                var Job5 = new JobEntity()
                {
                    Category = Domain.Enums.JobCategory.GeneralBuildingWork,
                    Client = clientFernanda,
                    ClientId = clientFernanda.Id,
                    Price = 200,
                    Status = Domain.Enums.JobStatus.Pendente,
                    CreatedAt = DateTime.Now,
                    Description = "I need help with landscaping my backyard. I'd like to create a low-maintenance garden with native plants, rocks, and a small water feature. I also need someone to trim the trees and bushes in the front yard."
                };

                var Job6 = new JobEntity()
                {
                    Category = Domain.Enums.JobCategory.GeneralBuildingWork,
                    Client = clientFernanda,
                    ClientId = clientFernanda.Id,
                    Price = 800,
                    Status = Domain.Enums.JobStatus.Pendente,
                    CreatedAt = DateTime.Now,
                    Description = "I have a leaky roof that needs to be fixed as soon as possible. I would like a professional to inspect the roof, identify the source of the leak, and provide an estimate for the repair. If the repair is not cost-effective, I would like to explore options for roof replacement."
                };

                var Job7 = new JobEntity()
                {
                    Category = Domain.Enums.JobCategory.InteriorPainters,
                    Client = clientFernanda,
                    ClientId = clientFernanda.Id,
                    Price = 500,
                    Status = Domain.Enums.JobStatus.Pendente,
                    CreatedAt = DateTime.Now,
                    Description = "I would like to paint the interior of my house. I need someone to prime and paint the walls, ceiling, and trim in the living room, dining room, and kitchen. I would like to schedule the work for next week and have it completed within two days."
                };

                context.Job.AddRange(new List<JobEntity>() { Job1, Job2, Job3, Job4, Job5, Job6, Job7 });

                context.SaveChanges();
            }
        }
    }
}

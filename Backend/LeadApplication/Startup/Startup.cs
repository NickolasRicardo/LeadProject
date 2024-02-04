using Domain.Services;
using LeadApplication.Domain.Commands.CreateTeste;
using LeadApplication.Domain.Interfaces.Services;
using LeadApplication.Domain.Query.ListTeste;
using LeadApplication.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeadApplication.API
{
    public class Startup : IStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencies(services);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
       
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LeadApplication v1"));
            }

            app.UseHttpsRedirection();

            app.MapControllers();
        }

        public void ConfigureDependencies(IServiceCollection services)
        {
            string conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(conn));

            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddScoped<IMediator, Mediator>();

            services.AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssemblies(
                        typeof(CreateTesteCommandHandler).Assembly,
                        typeof(ListTesteQueryHandler).Assembly)
            );

       
        }
    }
}

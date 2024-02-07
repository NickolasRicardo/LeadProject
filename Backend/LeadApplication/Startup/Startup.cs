using Domain.Services;
using LeadApplication.Domain.Commands.CreateTeste;
using LeadApplication.Domain.Interfaces.Repositories;
using LeadApplication.Domain.Interfaces.Services;
using LeadApplication.Domain.Query.ListTeste;
using LeadApplication.Infrastructure.Database;
using LeadApplication.Infrastructure.Database.Repository;
using LeadApplication.Infrastructure.Seed;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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
            services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
                ) ;

           services.AddCors(builder => builder.AddPolicy("AllowEveryone", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed((host) => true)));

        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LeadApplication v1"));
            }
            app.UseCors("AllowEveryone");
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

            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IMediator, Mediator>();

            services.AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssemblies(
                        typeof(UpdateJobCommandHandler).Assembly,
                        typeof(ListJobQueryHandler).Assembly)
            );


          

        }
    }
}

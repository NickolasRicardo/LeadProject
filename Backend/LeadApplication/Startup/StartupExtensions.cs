using LeadApplication.Infrastructure.Database;
using LeadApplication.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace LeadApplication.API
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(
            this WebApplicationBuilder WebAppBuilder
        )
            where TStartup : IStartup
        {
            var startup =
                Activator.CreateInstance(typeof(TStartup), WebAppBuilder.Configuration) as IStartup;
            if (startup == null)
                throw new ArgumentException("Classe Startup inválida!");

            startup.ConfigureServices(WebAppBuilder.Services);

            var app = WebAppBuilder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DatabaseContext>();
                context.Database.Migrate();
                DatabaseSeed.Seed(context);
            }

            startup.Configure(app, app.Environment);

            app.Run();

            return WebAppBuilder;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minibox.Presentation.Core.Data.Context.Main;
using Minibox.Presentation.Core.Data.Infrastructure.Interface;
using Minibox.Presentation.Core.Data.Infrastructure.Implementation;

namespace Minibox.Presentation.Core.Data.Extension
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddMainDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(nameof(MainDbContext)),
                x => x.MigrationsAssembly("BZ.Core.Data")));

            return services;
        }

        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork<MainDbContext>, UnitOfWork<MainDbContext>>();

            return services;
        }

        public static IServiceProvider UseAutoMigrationForMainDbContext(this IServiceProvider service)
        {
            using (var scope = service.CreateScope())
            {
                var mainDbContext = scope.ServiceProvider.GetRequiredService<MainDbContext>();
                mainDbContext.Database.Migrate();
            }
            return service;
        }
    }
}

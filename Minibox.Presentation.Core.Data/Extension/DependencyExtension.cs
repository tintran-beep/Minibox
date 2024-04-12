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
                x => x.MigrationsAssembly("Minibox.Presentation.Core.Data")));

            return services;
        }

        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork<MainDbContext>, UnitOfWork<MainDbContext>>();
        }

        public static async Task<IServiceProvider> MigrateAsync(this IServiceProvider service)
        {
            using (var scope = service.CreateScope())
            {
                using var mainDbContext = scope.ServiceProvider.GetRequiredService<MainDbContext>();
                await mainDbContext.Database.MigrateAsync();                
            }
            return service;
        }
    }
}

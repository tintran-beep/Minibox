using Microsoft.Extensions.DependencyInjection;
using Minibox.Presentation.Core.Service.Infrastructure.Interface;


namespace Minibox.Presentation.Core.Service.Extension
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddBussinessLogicLayer(this IServiceCollection services)
        {
            var implementedServices = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => !string.IsNullOrWhiteSpace(x.Name)
                                                                                                           && x.IsInterface == false
                                                                                                           && x.Name.EndsWith("Service")
                                                                                                           && x.GetInterfaces().Length > 0).ToList();
            if (implementedServices != null && implementedServices.Any())
            {
                implementedServices.ForEach(assignedTypes =>
                {
                    var serviceType = assignedTypes.GetInterfaces().FirstOrDefault(x => x.Name == $"I{assignedTypes.Name}");
                    if (serviceType != null)
                        services.AddScoped(serviceType, assignedTypes);
                });
            }

            return services;
        }

        public static async Task<IServiceProvider> SeedAdministrativeDirectoryDataAsync(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                try
                {
                    var service = scope.ServiceProvider.GetRequiredService<IAdministrativeDirectoryService>();
                    await service.SeedAsync();
                }
                catch (Exception ex)
                {

                }
                
            }
            return serviceProvider;
        }
    }
}

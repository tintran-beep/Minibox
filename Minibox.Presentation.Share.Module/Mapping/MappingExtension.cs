using Microsoft.Extensions.DependencyInjection;

namespace Minibox.Presentation.Share.Module.Mapping
{
    public static class MappingExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}

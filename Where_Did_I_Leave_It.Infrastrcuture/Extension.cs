using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Where_Did_I_Leave_It.Infrastrcuture.EF;

namespace Where_Did_I_Leave_It.Infrastrcuture
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);

            return services;
        }
    }
}

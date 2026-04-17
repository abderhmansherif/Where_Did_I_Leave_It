using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Where_Did_I_Leave_It.Application.Services;
using Where_Did_I_Leave_It.Domain.Repositories;
using Where_Did_I_Leave_It.Infrastrcuture.EF.Contexts;
using Where_Did_I_Leave_It.Infrastrcuture.EF.Options;
using Where_Did_I_Leave_It.Infrastrcuture.EF.Repositories;
using Where_Did_I_Leave_It.Infrastrcuture.EF.Services;

namespace Where_Did_I_Leave_It.Infrastrcuture.EF
{
    public static class Extension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetOption<NpgSqlSettings>("NpgSql");
            services.AddDbContext<ItemDbContext>(op => op.UseNpgsql(option.ConnectionString));

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemReadService, ItemReadServcie>();

            return services;
        }
    }
}

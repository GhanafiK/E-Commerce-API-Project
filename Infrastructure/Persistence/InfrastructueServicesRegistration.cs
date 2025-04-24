using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class InfrastructueServicesRegistration
    {
        public static IServiceCollection AddInfrastructueService(this IServiceCollection Services,IConfiguration Configuration)
        {
            Services.AddDbContext<StoreDbContext>(Options =>
            {
                Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            Services.AddScoped<IDataSeeding, DataSeeding>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services.AddScoped<IBasketRepository, BasketRepository>();

            Services.AddSingleton<IConnectionMultiplexer>((_) =>
            {
                return ConnectionMultiplexer.Connect(Configuration.GetConnectionString("RedisConnectionString"));
            });
            return Services;
        }
    }
}

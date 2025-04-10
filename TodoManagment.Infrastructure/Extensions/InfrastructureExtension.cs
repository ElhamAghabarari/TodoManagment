using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Core.Interfaces;
using TodoManagment.Infrastructure;
using TodoManagment.Infrastructure.Repositoty;

namespace TodoManagment.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<Context>(options =>
                options.UseNpgsql(conf.GetConnectionString("LocalhostConnection")));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

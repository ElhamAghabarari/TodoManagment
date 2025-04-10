using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagment.Core.Interfaces;
using TodoManagment.Core.Services;

namespace TodoManagment.Core.Extensions
{
    public static class CoreExtention
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITaskService, TaskService>();
        }
    }
}

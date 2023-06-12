using BugTracker.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BugDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BugDatabase")));
            services.AddScoped<IBugDbContext, BugDbContext>();
            return services;     
        }

    }
}

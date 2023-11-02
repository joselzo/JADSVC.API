

using JADSVC.Data.DataDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JAD.API.Extensions.DbContext
{
    public static class ContextExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JadsvcsContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
           );
            return services;
        }
    }
}

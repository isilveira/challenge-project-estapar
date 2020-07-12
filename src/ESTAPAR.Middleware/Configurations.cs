using ESTAPAR.Core.Application;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Contexts;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using ESTAPAR.Core.Domain.Interfaces.Services;
using ESTAPAR.Core.Domain.Services;
using ESTAPAR.Infrastructures.Data;
using ESTAPAR.Infrastructures.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ESTAPAR.Middleware
{
    public static class Configurations
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IEstaparDbContext, EstaparDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICarroRepository, CarroRepository>();
            services.AddTransient<IManobraRepository, ManobraRepository>();
            services.AddTransient<IManobristaRepository, ManobristaRepository>();

            services.AddTransient<ICarroDomainService, CarroDomainService>();
            services.AddTransient<IManobraDomainService, ManobraDomainService>();
            services.AddTransient<IManobristaDomainService, ManobristaDomainService>();

            services.AddTransient<CarroApplicationService>();
            services.AddTransient<ManobraApplicationService>();
            services.AddTransient<ManobristaApplicationService>();

            // YOUR CODE GOES HERE

            return services;
        }
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            // YOUR CODE GOES HERE
            return app;
        }
    }
}

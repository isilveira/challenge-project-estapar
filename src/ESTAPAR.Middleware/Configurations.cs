using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ESTAPAR.Middleware
{
    public static class Configurations
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
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

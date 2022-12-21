using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MrLink.Application.Interfaces;

namespace MrLink.Persistence.MrLinkPersistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<LinkDbContext>(options => options.UseInMemoryDatabase("Hi"));

            services.AddScoped<ILinkDbContext>(provider =>
               provider.GetService<LinkDbContext>());

            return services;
        }
    }
}

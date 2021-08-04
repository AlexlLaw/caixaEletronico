using caixaEletronico.data;
using caixaEletronico.services;
using Microsoft.Extensions.DependencyInjection;

namespace caixaEletronico.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddRepositorys(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ITipoContaRepository, TipoContaRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();

            return services;
        }

          public static IServiceCollection AddServices(this IServiceCollection services)
        {
             services.AddScoped<IContaService, ContaService>();
            return services;
        }
    }
}
using caixaEletronico.data;
using caixaEletronico.services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using caixaEletronico.DTO.Validators;

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

        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddControllers()
             .AddFluentValidation(Config => Config.RegisterValidatorsFromAssemblyContaining<PesssoaValidator>())
             .AddFluentValidation(Config => Config.RegisterValidatorsFromAssemblyContaining<EnderecoValidator>());
            return services;
        }
    }
}
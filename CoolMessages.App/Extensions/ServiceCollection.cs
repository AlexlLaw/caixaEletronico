using CoolMessages.App.Data;
using CoolMessages.App.Extensions;
using Microsoft.Extensions.DependencyInjection;
using CoolMessages.App.Consumers;
using CoolMessages.App.Services;


namespace CoolMessages.App.Extensions
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
             services.AddScoped<IConsumerService, ConsumerService>();
             services.AddScoped<INotificationService, NotificationService>();
             return services;
        }

        public static IServiceCollection AddHosted(this IServiceCollection services)
        {
            services.AddHostedService<ProcessMessageConsumer>();
            return services;
        }
    }
}
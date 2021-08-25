using CoolMessages.App.Models;
using CoolMessages.App.Options;
using CoolMessages.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoolMessages.App.Consumers
{
    public class ProcessMessageConsumer : BackgroundService
    {
        private readonly RabbitMqConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        public ProcessMessageConsumer(IOptions<RabbitMqConfiguration> option, IServiceProvider serviceProvider)
        {
           
            _configuration = option.Value;
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = _configuration.Host
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                        queue: _configuration.Queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonConvert.DeserializeObject<MessageInputModel>(contentString);
           
                this.Post(message);
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(_configuration.Queue, false, consumer);

            return Task.CompletedTask;
        }

        public async void Post(MessageInputModel message)
        {
             using (var scope = _serviceProvider.CreateScope())
             {
                 var consumerService = scope.ServiceProvider.GetRequiredService<IConsumerService>();
    
                 consumerService.addTransferencia(message);
               
                 if (await consumerService.SaveChangesAsync()) {
                      Console.WriteLine("transferencia completa");
                      return;
                 }

                 Console.WriteLine("Ocorreu um erro na transação");
             }
        }

        public async Task<Conta> getDados()
        {
             using (var scope = _serviceProvider.CreateScope())
             {
                var consumerService = scope.ServiceProvider.GetRequiredService<IConsumerService>();
    
                var result = await consumerService.GetContaById(1);

               return result;
             }
        }
    }
}
 
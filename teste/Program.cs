using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Linq;
using System.Text;

namespace teste
{
    class Program
    {
         private const string QUEUE_NAME = "transferencias";
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //Eu declaro a fila caso ela não exita, ela criara uma
                    channel.QueueDeclare(
                        queue: QUEUE_NAME,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"[x] Recebida: { message}");
                    };
                    channel.BasicConsume(queue: QUEUE_NAME,
                    autoAck: true,
                    consumer: consumer);

                   Console.WriteLine("Consumido com sucesso");
                }
            }
        }
    }
}

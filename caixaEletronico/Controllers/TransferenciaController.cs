using System.Text;
using System.Text.Json;
using caixaEletronico.DTO;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace caixaEletronico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private const string QUEUE_NAME = "transferencias"; 
        private readonly ConnectionFactory _factory;

        public TransferenciaController()
        {
            _factory = new ConnectionFactory 
            {
                HostName = "localhost"
            };
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] TransacoesDTO model)
        {
            using (var connection = _factory.CreateConnection())
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

                    //Formatar os dados para enviar para a fila
                    var stringTransactions = JsonSerializer.Serialize(model);
                    var byteArray = Encoding.UTF8.GetBytes(stringTransactions);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: QUEUE_NAME,
                        basicProperties: null,
                        body: byteArray
                    );
                }
            }
            return Accepted();
        }
    }
}
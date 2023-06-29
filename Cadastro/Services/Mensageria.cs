using System.Text;
using RabbitMQ.Client;

namespace Cadastro.Services
{
    public class Mensageria : IMensageria
    {
        private const string NOME_FILA = "PEDIDO_CRIADO";
        public void Enviar(string message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            CriarFila(channel);

            var body = Encoding.UTF8.GetBytes(message);

            Publish(channel, body);

        }

        private void Publish(IModel channel, byte[] body){
            channel.BasicPublish(exchange: string.Empty,
                                routingKey: NOME_FILA,
                                basicProperties: null,
                                body: body);
        }

        private void CriarFila(IModel channel){
            channel.QueueDeclare(
                    queue: NOME_FILA,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
            );
        }


    }
}
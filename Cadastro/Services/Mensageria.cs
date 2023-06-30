using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using Cadastro.Model;

namespace Cadastro.Services
{
    public class Mensageria : IMensageria
    {
        private const string NOME_FILA = "PEDIDO_CRIADO";
        public void Enviar(PedidoModel pedido)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            CriarFila(channel);

            string mensagemConvertida = JsonSerializer.Serialize(new { pedido.Id, pedido.CreateAt, pedido.FormaPagamento, pedido.ValorTotal });

            var body = Encoding.UTF8.GetBytes(mensagemConvertida);

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
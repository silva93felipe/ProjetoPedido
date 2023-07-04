using System.Text;
using System.Text.Json;
using Financeiro.Model;
using Financeiro.Repositories;
using Financeiro.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Cadastro.Services
{
    public class Mensageria : IMensageria
    {
        private const string NOME_FILA_CRIACAO_PEDIDO = "PEDIDO_CRIADO";
        private const string NOME_FILA_PAGAMENTO = "PAGAMENTO_APROVADO";

        private readonly IPagamentoRepository _pagamentoRepository;
        public Mensageria(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;   
        }

        public void Enviar(Pagamento pagamento)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            CriarFila(channel);

            string mensagemConvertida = JsonSerializer.Serialize(new { pagamento.PedidoId, pagamento.StatusPagamento });

            var body = Encoding.UTF8.GetBytes(mensagemConvertida);

            Publish(channel, body);
        }

        private void Publish(IModel channel, byte[] body){
            channel.BasicPublish(exchange: string.Empty,
                                routingKey: NOME_FILA_PAGAMENTO,
                                basicProperties: null,
                                body: body);
        }

        private void CriarFila(IModel channel){
            channel.QueueDeclare(
                    queue: NOME_FILA_PAGAMENTO,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
            );
        }

        public void Receber()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var pedido = JsonSerializer.Deserialize<PedidoReceiveMessage>(message);
                var pagamentoNew = new Pagamento();
                pagamentoNew.TipoPagamento = pedido.FormaPamento;
                pagamentoNew.PedidoId = pedido.Id;
                pagamentoNew.Parcelas = 1;
                pagamentoNew.ValorTotal = pedido.ValorTotal;

                _pagamentoRepository.Create(pagamentoNew);

                Console.WriteLine($" [x] Received {message}");
            };

            channel.BasicConsume(queue: NOME_FILA_CRIACAO_PEDIDO,
                                autoAck: true,
                                consumer: consumer);
        }
    }
}


class PedidoReceiveMessage{
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public int FormaPamento {get; set;}
    public double ValorTotal { get; set; }
}
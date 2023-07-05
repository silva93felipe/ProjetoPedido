using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Financeiro.Context;
using Financeiro.DTO;
using Financeiro.Model;
using Financeiro.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Financeiro.Consumer
{
    public class ProcessMessageConsumer : BackgroundService
    {
        private const string FILA_PEDIDO_CRIADO = "PEDIDO_CRIADO";
        private const string FILA_PAGAMENTO = "PAGAMENTO_APROVADO";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly FinanceiroContext _financeiroContext;


        public ProcessMessageConsumer(FinanceiroContext financeiroContext)
        {            
            var factory = new ConnectionFactory { HostName = "localhost" };
            _financeiroContext = financeiroContext;
            
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            CriarFila(_channel);
        }

        public void Enviar(Pagamento pagamento)
        {
            string mensagemConvertida = JsonSerializer.Serialize(new { pagamento.PedidoId, pagamento.StatusPagamento });

            var body = Encoding.UTF8.GetBytes(mensagemConvertida);

            Publish(_channel, body);
        }

        private void Publish(IModel channel, byte[] body)
        {
            channel.BasicPublish(exchange: string.Empty,
                                routingKey: FILA_PAGAMENTO,
                                basicProperties: null,
                                body: body);
        }

        private void CriarFila(IModel channel)
        {
            channel.QueueDeclare(
                    queue: FILA_PAGAMENTO,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
            );
        }

        public void Receber()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var pedidoReceive = JsonSerializer.Deserialize<PedidoReceiveMessage>(message);
                var newPedido = new Pagamento();
                newPedido.PedidoId = pedidoReceive.Id;
                newPedido.TipoPagamento = pedidoReceive.FormaPamento;
                newPedido.ValorTotal  = pedidoReceive.ValorTotal;
                newPedido.CreateAt = pedidoReceive.CreateAt; 

                _financeiroContext.Add(newPedido);


                Console.WriteLine($" [x] Received {message}");
            };

            _channel.BasicConsume(queue: FILA_PEDIDO_CRIADO,
                                autoAck: true,
                                consumer: consumer);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Receber();

            return Task.CompletedTask;
        }
    }
}

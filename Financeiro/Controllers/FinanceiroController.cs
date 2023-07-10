
using Financeiro.DTO;
using Financeiro.Enum;
using Financeiro.Model;
using Financeiro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Financeiro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceiroController : ControllerBase
    {   
        private readonly IPagamentoRepository _pagamentoRepository;

        public FinanceiroController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        [HttpGet]
        [Route("StatusPagamento")]
        public IActionResult StatusPagamento(Guid pedidoId )
        {
            var pagamento = _pagamentoRepository.GetById(pedidoId);
            return Ok(pagamento.StatusPagamento);
        }

        [HttpPost]
        public IActionResult Crete(PedidoRequest newPedido )
        {
            Pagamento newPagamento = new Pagamento();

            newPagamento.PedidoId = newPedido.Id;
            newPagamento.ValorTotal = newPedido.ValorTotal;
            newPagamento.CreateAt = newPedido.CreateAt;
            newPagamento.TipoPagamento = newPedido.FormaPamento;

            try
            {
                _pagamentoRepository.Create(newPagamento);

                newPagamento.PagamentoAprovado();

                _pagamentoRepository.SaveChanges();
                
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cadastro.Repositories;
using Cadastro.Model;
using Cadastro.DTO;

namespace Cadastro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Pedido : ControllerBase
    {   
        private readonly IPedidoRepository _pedidoRepository;

        public Pedido(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpPost]
        public IActionResult Create( PedidoDTORequest pedido)
        {

            PedidoModel pedidoModel = new PedidoModel();
            List<ItensPedido> itensPedidoModel = new List<ItensPedido>(); 
            
            foreach (var item in pedido.Itens)
            {
                ItensPedido itemPedidoModel = new ItensPedido();
                itemPedidoModel.Descricao = item.Descricao;
                itemPedidoModel.Quantidade = item.Quantidade;
                itemPedidoModel.Valor = item.Valor;

                pedidoModel.Itens.Add(itemPedidoModel);
            }

            pedidoModel.FormaPagamento = pedido.FormaPagamento;

            _pedidoRepository.Create(pedidoModel);
            return Ok();
        }

       [HttpGet("{id}")]
        public IActionResult Status(Guid id){
            PedidoDTOResponse pedidoResponse = new PedidoDTOResponse();

            var pedido = _pedidoRepository.GetById(id);
            if(pedido == null){
                return NotFound();
            }

            pedidoResponse.FormaPagamento = pedido.FormaPagamento;
            pedidoResponse.Id = pedido.Id;
            pedidoResponse.ValorTotal = pedido.ValorTotal;

            return Ok(pedidoResponse);
        }

        [HttpGet]
        public IActionResult GetAll(){
            List<PedidoDTOResponse> pedidosResponse = new  List<PedidoDTOResponse>();

            var pedidos = _pedidoRepository.GetAll();
            
            if(pedidos != null && pedidos.Count() > 0){
                foreach (var pedido in pedidos)
                {
                    PedidoDTOResponse pedidoResponse = new PedidoDTOResponse();
                    pedidoResponse.FormaPagamento = pedido.FormaPagamento;
                    pedidoResponse.Id = pedido.Id;
                    pedidoResponse.ValorTotal = pedido.ValorTotal;
                    pedidosResponse.Add(pedidoResponse);
                }

                return Ok(pedidosResponse);
            }

            return NotFound();

        }

        [HttpDelete("{id}")]
        public IActionResult Cancelar(Guid id){
            _pedidoRepository.Delete(id);
            return NoContent();
        }
    }
}
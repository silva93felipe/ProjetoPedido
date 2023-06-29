using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cadastro.Repositories;
using Cadastro.Model;

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
        public IActionResult Create( PedidoModel pedido){
            _pedidoRepository.Create(pedido);
            return Ok();
        }

       [HttpGet("{id}")]
        public IActionResult Status(Guid id){
            _pedidoRepository.GetById(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll(){
            _pedidoRepository.GetAll();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Cancelar(Guid id){
            _pedidoRepository.Delete(id);
            return Ok();
        }
    }
}
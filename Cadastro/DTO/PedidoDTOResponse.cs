using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Enum;

namespace Cadastro.DTO
{
    public class PedidoDTOResponse
    {
        public Guid Id { get; set; }
        public ICollection<ItensPedidoDTOResponse> Itens { get; set; }
        public StatusPedidoEnum Status {get;  set;}
        public double ValorTotal { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; } 
        
    }
}
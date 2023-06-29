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
        public ICollection<ItensPedidoDTORequest> Itens { get; }
        public double ValorTotal { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; } 
        
    }
}
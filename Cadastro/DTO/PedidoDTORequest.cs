using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Enum;

namespace Cadastro.DTO
{
    public class PedidoDTORequest
    {
        public ICollection<ItensPedidoDTORequest> Itens { get; set;}
        public FormaPagamentoEnum FormaPagamento { get; set; } 
        public PedidoDTORequest(){
            Itens = new List<ItensPedidoDTORequest>();
        }
    }
}
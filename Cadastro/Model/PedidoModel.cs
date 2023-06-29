using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Enum;

namespace Cadastro.Model
{
    public class PedidoModel : BaseModel<Guid>
    {
        public ICollection<ItensPedido> Itens { get; }
        public double ValorTotal { get; private set; }
        public StatusPedidoEnum Status {get; private set;}
        public FormaPagamentoEnum FormaPagamento { get; private set; } 

        public PedidoModel()
        {
            Itens = new List<ItensPedido>();
            Status = StatusPedidoEnum.CRIADO;
        }
        public PedidoModel(FormaPagamentoEnum formaPagamento): this()
        {
            FormaPagamento = formaPagamento;
        }

        public double CalcularValorTotal(){
            ValorTotal = Itens.Sum(i => i.ValorTotal());
            return ValorTotal;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financeiro.Enum;

namespace Financeiro.Model
{
    public class Pagamento : BaseModel<Guid>
    {
        public int TipoPagamento { get; set; }
        public double ValorTotal { get; set; }
        public Guid PedidoId { get; set; }
        public int Parcelas { get; set; }
        public StatusPagamentoEnum StatusPagamento { get; private set; }

        public Pagamento()
        {
            StatusPagamento = StatusPagamentoEnum.PENDENTE;
        }


    }
}
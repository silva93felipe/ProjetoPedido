using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.DTO
{
    class PedidoReceiveMessage
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public int FormaPamento { get; set; }
        public double ValorTotal { get; set; }
    }
}
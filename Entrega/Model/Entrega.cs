using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrega.Model
{
    public class Entrega : BaseModel<int>
    {
        public Guid PedidoId { get; set; }
        public DateTime DataCadastroPedido {get; set;}
        public Endereco Endereco {get; set;}
    }
}
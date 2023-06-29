using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Model
{
    public class ItensPedido : BaseModel<int>
    {
        public string Descricao { get; set; }
        public double Quantidade {get; set; }
        public double Valor {get; set; }

        public double ValorTotal (){
            return Quantidade * Valor;
        }
    }
}
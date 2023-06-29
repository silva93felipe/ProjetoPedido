using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Model
{
    public class ItensPedido : BaseModel<int>
    {
        public string Descricao { get; private set; }
        public double Quantidade {get; private set; }
        public double Valor {get; private set; }

        public double ValorTotal (){
            return Quantidade * Valor;
        }
    }
}
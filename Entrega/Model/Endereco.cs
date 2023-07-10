using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrega.Model
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Municipio { get; set; }
        public string UF {get; set;}
        public string Logradouro {get; set;}
    }
}
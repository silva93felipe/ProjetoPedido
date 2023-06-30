using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Model;

namespace Cadastro.Services
{
    public interface IMensageria
    {
        void Enviar(PedidoModel message);
    }
}
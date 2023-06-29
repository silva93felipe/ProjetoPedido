using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Services
{
    public interface IMensageria
    {
        void Enviar(string message);
    }
}
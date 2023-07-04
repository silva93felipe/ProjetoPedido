using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financeiro.Model;

namespace Financeiro.Services
{
    public interface IMensageria
    {
        void Enviar(Pagamento message);
        void Receber();
    }
}
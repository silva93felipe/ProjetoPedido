using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Services
{
    public interface IGerarFinanceiro
    {
        public Task Gerar(string message);
        public Task StatusPagamento();
    }
}
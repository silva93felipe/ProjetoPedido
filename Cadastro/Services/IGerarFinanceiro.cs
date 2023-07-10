using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Model;

namespace Cadastro.Services
{
    public interface IGerarFinanceiro
    {
        public Task<bool> GerarPagamento(PedidoModel pedido);
        public Task<int> StatusPagamento(Guid pedidoId);
    }
}
using Financeiro.Context;
using Financeiro.Model;
using Cadastro.Services;
using Microsoft.EntityFrameworkCore;
using Financeiro.Services;

namespace Financeiro.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly IMensageria _mensageria;
        private readonly FinanceiroContext _financeiroContext;

        public PagamentoRepository(FinanceiroContext financeiroContext, IMensageria mensageria)
        {
            _financeiroContext = financeiroContext;
            _mensageria = mensageria;
        }

        public void Create(Pagamento entity)
        {
            _financeiroContext.Add(entity);
            SaveChanges();
            _mensageria.Enviar(entity);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pagamento> GetAll()
        {
            return _financeiroContext.Pagamentos;
        }

        public Pagamento GetById(Guid id)
        {
            return _financeiroContext.Pagamentos.FirstOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _financeiroContext.SaveChanges();
        }

        public void Update(Pagamento entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
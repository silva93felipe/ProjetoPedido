using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Context;
using Cadastro.Model;
using Cadastro.Services;

namespace Cadastro.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMensageria _mensageria;
        private readonly CadastroContext _cadastroContext;

        public PedidoRepository(CadastroContext cadastroContext, IMensageria mensageria)
        {
            _cadastroContext = cadastroContext;
            _mensageria = mensageria;
        }

        public void Create(PedidoModel entity)
        {
            _cadastroContext.Add(entity);
            SaveChanges();
            _mensageria.Enviar(entity.Id.ToString());
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PedidoModel> GetAll()
        {
            return _cadastroContext.Pedidos;
        }

        public PedidoModel GetById(Guid id)
        {
            return _cadastroContext.Pedidos.FirstOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _cadastroContext.SaveChanges();
        }

        public void Update(PedidoModel entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
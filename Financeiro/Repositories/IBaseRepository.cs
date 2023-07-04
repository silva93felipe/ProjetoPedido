using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financeiro.Model;

namespace Financeiro.Repositories
{
    public interface IBaseRepository<T, K>
    {
        void SaveChanges();
        T GetById(K id);
        void Create(T entity);
        void Delete(K id);
        IEnumerable<T> GetAll();
        void Update(T entity, K id);
    }
}
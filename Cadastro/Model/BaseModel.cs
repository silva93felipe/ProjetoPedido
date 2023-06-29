using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Model
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public BaseModel(){
            Ativo = true;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}
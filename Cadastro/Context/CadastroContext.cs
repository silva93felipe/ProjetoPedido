using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cadastro.Model;

namespace Cadastro.Context
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options): base(options){}

        public DbSet<PedidoModel> Pedidos {get; set;}
        public DbSet<ItensPedido> ItensPedido {get; set;}
    }
}
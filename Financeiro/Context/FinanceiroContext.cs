using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Financeiro.Model;

namespace Financeiro.Context
{
    public class FinanceiroContext : DbContext
    {
        public FinanceiroContext(DbContextOptions<FinanceiroContext> options): base(options){}

        public DbSet<Pagamento> Pagamentos {get; set;}
    }
}
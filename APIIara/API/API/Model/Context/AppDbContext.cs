using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() {}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<CotacaoItem> CotacaoItens { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace TGCTE.Entities
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Cte> Cte{ get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<Ocorrencia> Ocorrencia { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Entities
{
    public class ContextoBanco:DbContext
    {
        public ContextoBanco(DbContextOptions<ContextoBanco> options):base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Locacoes> Locacoes { get; set; }




    }
}

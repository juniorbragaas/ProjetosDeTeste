using System;
using ApiCrud.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiCrud.Models
{
    public partial class APIContext : DbContext
    {
        public APIContext()
        {
        }

        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Filme> Filme { get; set; }
        public virtual DbSet<Locacao> Locacao { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

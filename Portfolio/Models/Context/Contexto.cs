using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Models.Entities;

namespace Portfolio.Models.Context
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("PortfolioDB")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());
            modelBuilder.Entity<Cliente>().HasKey(x => x.ClienteId);
            modelBuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar")
                    .HasMaxLength(50));

            base.OnModelCreating(modelBuilder);
        }
    }
}

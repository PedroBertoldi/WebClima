using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using WebClima.Models;

namespace WebClima.Data
{
    public class WebClimaContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<PrevisaoClima> Previsoes { get; set; }

        public WebClimaContext() : base("ClimaTempoSimples")
        {
        }
        public WebClimaContext(string connectionString) : base(connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
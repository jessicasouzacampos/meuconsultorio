using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MeuConsultorio.Mapeamento;
using MeuConsultorio.Models;

namespace MeuConsultorio.Models
{
    public class MeuConsultorioContext : DbContext
    {
        public MeuConsultorioContext() : base("MeuConsultorio")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProcedimentoMap());

            base.OnModelCreating(modelBuilder);      
        }

        public DbSet<TipoAtendimento> TiposAtendimentos { get; set; }
        public DbSet<Convenio> Convenios { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }  
        public DbSet<ProcedimentoConvenio> ProcedimentosConvenios { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
    }
}
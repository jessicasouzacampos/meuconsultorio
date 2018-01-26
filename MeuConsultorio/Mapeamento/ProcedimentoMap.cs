using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MeuConsultorio.Models;

namespace MeuConsultorio.Mapeamento
{
    public class ProcedimentoMap : EntityTypeConfiguration<Procedimento>
    {
        public ProcedimentoMap()
        {
            HasRequired(x => x.TipoAtendimento)
                .WithMany(o => o.Procedimentos)
                .HasForeignKey(o=>o.TipoAtendimentoId)
                .WillCascadeOnDelete(false);
        }
    }
}
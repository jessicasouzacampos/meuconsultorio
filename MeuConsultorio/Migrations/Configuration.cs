using System.Collections.Generic;
using MeuConsultorio.Models;

namespace MeuConsultorio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MeuConsultorio.Models.MeuConsultorioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MeuConsultorio.Models.MeuConsultorioContext context)
        {
            if (!context.TiposAtendimentos.Any())
            {
                List<TipoAtendimento> tipos = new List<TipoAtendimento>()
                {
                    new TipoAtendimento(){TipoAtendimentoId = 1, Codigo = 1,Descricao = "Consulta"},
                    new TipoAtendimento(){TipoAtendimentoId = 2, Codigo = 2,Descricao = "Curativo"},
                    new TipoAtendimento(){TipoAtendimentoId = 3, Codigo = 3,Descricao = "Exame"}
                };
                context.TiposAtendimentos.AddRange(tipos);
                context.SaveChanges();
            }


            if (!context.Convenios.Any())
            {
                List<Convenio> convenios = new List<Convenio>()
                {
                    new Convenio() {ConvenioId = 1, Codigo = 1, Descricao = "Particular", Fatura = false},
                    new Convenio() {ConvenioId = 2, Codigo = 2, Descricao = "Unimed", Fatura = true},
                    new Convenio() {ConvenioId = 3, Codigo = 3, Descricao = "Saúde Vida", Fatura = true}
                };

                context.Convenios.AddRange(convenios);
                context.SaveChanges();
            }

            if (!context.Procedimentos.Any())
            {
                List<Procedimento> procedimentos = new List<Procedimento>()
                {
                    new Procedimento(){ProcedimentoId = 1, Codigo = 1,Descricao = "Consulta médica",TipoAtendimentoId = 1},
                    new Procedimento(){ProcedimentoId = 2,Codigo = 2,Descricao = "Consulta de aconselhamento para planejamento familiar",TipoAtendimentoId = 1},
                    new Procedimento(){ProcedimentoId = 3,Codigo = 3,Descricao = "Consulta individual",TipoAtendimentoId = 1},
                    new Procedimento(){ProcedimentoId = 4,Codigo = 4,Descricao = "Curativos em geral c/ ou s/ anestesia",TipoAtendimentoId = 2},
                    new Procedimento(){ProcedimentoId = 5,Codigo = 5,Descricao = "Curativo de queimadura",TipoAtendimentoId = 2},
                    new Procedimento(){ProcedimentoId = 6,Codigo = 6,Descricao = "Curativo especial sob anestesia",TipoAtendimentoId = 2},
                    new Procedimento(){ProcedimentoId = 7,Codigo = 7,Descricao = "Endoscopia",TipoAtendimentoId = 3},
                    new Procedimento(){ProcedimentoId = 8,Codigo = 8,Descricao = "Mamografia",TipoAtendimentoId = 3}
                };
                context.Procedimentos.AddRange(procedimentos);
                context.SaveChanges();
            }

            if (!context.Procedimentos.Any())
            {
                List<ProcedimentoConvenio> procedimentos_convenios = new List<ProcedimentoConvenio>()
                {
                    new ProcedimentoConvenio(){ProcedimentoConvenioId = 1, Valor = 40, Codigo = 1, ConvenioId = 1, ProcedimentoId = 1},
                    new ProcedimentoConvenio(){ProcedimentoConvenioId = 2, Valor = 25, Codigo = 2, ConvenioId = 1, ProcedimentoId = 6},
                    new ProcedimentoConvenio(){ProcedimentoConvenioId = 3, Valor = 200, Codigo = 3, ConvenioId = 3, ProcedimentoId = 1},
                    new ProcedimentoConvenio(){ProcedimentoConvenioId = 4, Valor = 41, Codigo = 4, ConvenioId = 2, ProcedimentoId = 1},
                    new ProcedimentoConvenio(){ProcedimentoConvenioId = 5, Valor = 88, Codigo = 5, ConvenioId = 2, ProcedimentoId = 7},
                    new ProcedimentoConvenio(){ProcedimentoConvenioId = 6, Valor = 75, Codigo = 6, ConvenioId = 1, ProcedimentoId = 7},
                    new ProcedimentoConvenio(){ProcedimentoConvenioId = 7, Valor = 600, Codigo = 7, ConvenioId = 3, ProcedimentoId = 7}
                };
                context.ProcedimentosConvenios.AddRange(procedimentos_convenios);
                context.SaveChanges();
            }
 
        }
    }
}

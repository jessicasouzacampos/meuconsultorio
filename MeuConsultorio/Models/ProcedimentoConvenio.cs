using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuConsultorio.Models
{
    public class ProcedimentoConvenio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcedimentoConvenioId { get; set; }

        [Required]
        [Index("IUQ_ProcedimentoConvenio_Codigo")]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [ForeignKey("Procedimento")]
        [Index("IUQ_ProcedimentoConvenio_ProcedimentoId_ConvenioId", IsUnique = true, Order = 1)]
        public int ProcedimentoId { get; set; }

        [ForeignKey("Convenio")]
        [Index("IUQ_ProcedimentoConvenio_ProcedimentoId_ConvenioId", IsUnique = true, Order = 2)]
        public int ConvenioId { get; set; }

        [Display(Name = "Valor do procedimento")]
        public decimal Valor { get; set; }

        public virtual Convenio Convenio { get; set; }  
        public virtual Procedimento Procedimento { get; set; }
    }
}

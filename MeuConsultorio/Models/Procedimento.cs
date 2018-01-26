using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MeuConsultorio.Models
{
    [Table("Procedimento")]
    public class Procedimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcedimentoId { get; set; }

        [Required]
        [Index("IUQ_Procedimento_Codigo")]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        [Index("IUQ_Procedimento_Descricao")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Tipo do atendimento")]
        [ForeignKey("TipoAtendimento")]
        public int TipoAtendimentoId { get; set; }
        
        public virtual TipoAtendimento TipoAtendimento { get; set; }

    }
}
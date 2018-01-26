using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuConsultorio.Models
{
    [Table("Atendimento")]
    public class Atendimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtendimentoId { get; set; }

        [Required]
        [Index("IUQ_Atendimento_Codigo")]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required]  
        [Display(Name = "Nome do paciente")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "A data e a hora do atendimento são obrigatórios")]
        [Display(Name = "Data e hora do atendimento")]
        public DateTime DataHora { get; set; }    
       
        [ForeignKey("Convenio")]
        [Display(Name = "Convênio")]
        public int ConvenioId { get; set; }

        [ForeignKey("TipoAtendimento")]
        [Display(Name = "Tipo do atendimento")]
        public int TipoAtendimentoId { get; set; }

        [ForeignKey("Procedimento")]
        [Display(Name = "Tipo de procedimento")]
        public int ProcedimentoId { get; set; }

        public virtual Convenio Convenio { get; set; }
        public virtual TipoAtendimento TipoAtendimento { get; set; }
        public virtual Procedimento Procedimento { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
        

    }
}
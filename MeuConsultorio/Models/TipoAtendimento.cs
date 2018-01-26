using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuConsultorio.Models
{
    [Table("TipoAtendimento")]
    public class TipoAtendimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoAtendimentoId { get; set; }

        [Required]
        [Index("IUQ_TipoAtendimento_Codigo")]
        [Display(Name = "Código")]
        public int Codigo { get; set; }
       
        [Required]
        [StringLength(100)]
        [Index("IUQ_TipoAtendimento_Descricao")]
        [Display(Name = "Descrição")]
        public string  Descricao { get; set; }        
       
        public virtual ICollection<Procedimento> Procedimentos { get; set; }
    }
}
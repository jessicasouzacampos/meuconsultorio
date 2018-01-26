using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuConsultorio.Models
{
    [Table("Convenio")]
    public class Convenio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConvenioId { get; set; }

        [Required]
        [Index("IUQ_Convenio_Codigo")]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        [Index("IUQ_Convenio_Descricao")]
        [Display(Name = "Descrição")]
        public string  Descricao { get; set; }

        [Required]
        [Display(Name = "Fatura")]
        public bool Fatura { get; set; }
    }
}
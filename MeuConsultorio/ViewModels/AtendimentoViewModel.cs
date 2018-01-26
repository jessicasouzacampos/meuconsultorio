using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuConsultorio.Models;

namespace MeuConsultorio.ViewModels
{
    public class AtendimentoViewModel
    {
        public AtendimentoViewModel()
        {
            Convenios = new List<SelectListItem>();
            TipoAtendimentos = new List<SelectListItem>();
            Procedimentos = new List<SelectListItem>();    
        }

        public int AtendimentoId { get; set; }

        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required]
        [Display(Name = "Nome do paciente")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "A data e a hora do atendimento são obrigatórios")]
        [Display(Name = "Data e hora do atendimento")]
        public DateTime DataHora { get; set; }

        [Display(Name = "Convênio")]
        public int ConvenioId { get; set; }
       
        [Display(Name = "Tipo do atendimento")]
        public int TipoAtendimentoId { get; set; }
        
        [Display(Name = "Tipo de procedimento")]
        public int ProcedimentoId { get; set; }

        public List<SelectListItem> Convenios { get; set; }
        public List<SelectListItem> TipoAtendimentos { get; set; }
        public List<SelectListItem> Procedimentos { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
    }
}
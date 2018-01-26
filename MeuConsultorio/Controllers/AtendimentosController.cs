using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuConsultorio.Models;
using MeuConsultorio.ViewModels;

namespace MeuConsultorio.Controllers
{   
    public class AtendimentosController : Controller
    {
        private MeuConsultorioContext context = new MeuConsultorioContext();

        //
        // GET: /Atendimentos/

        public ViewResult Indice()
        {
            return View(context.Atendimentos.Include(atendimento => atendimento.Convenio).Include(atendimento => atendimento.TipoAtendimento).Include(atendimento => atendimento.Procedimento).ToList());
        }

        //
        // GET: /Atendimentos/Detalhes/5

        public ViewResult Detalhes(int id)
        {
            Atendimento atendimento = context.Atendimentos.Single(x => x.AtendimentoId == id);
            return View(atendimento);
        }

        [HttpPost]
        public JsonResult AjaxMethod(int inputConvenio, int inputTipoAtendimento)
        {
            AtendimentoViewModel model = Carregar(inputConvenio, inputTipoAtendimento);

            return Json(model);
        }

        private AtendimentoViewModel Carregar(int inputConvenio, int inputTipoAtendimento)
        {
            AtendimentoViewModel model = new AtendimentoViewModel();

            var procedimentos = context.ProcedimentosConvenios
                .Where(o => o.ConvenioId == inputConvenio)
                .Include(o => o.Convenio)
                .Select(o => o.Procedimento)
                .Include(o => o.TipoAtendimento)
                .Where(o => o.TipoAtendimentoId == inputTipoAtendimento);

            foreach (var proced in procedimentos)
            {
                model.Procedimentos.Add(new SelectListItem { Text = proced.Descricao, Value = proced.ProcedimentoId.ToString() });
                model.TipoAtendimentos.Add(new SelectListItem { Text = proced.TipoAtendimento.Descricao, Value = proced.TipoAtendimento.TipoAtendimentoId.ToString() });
            }



            return model;
        }

        public int ProximoCodigo()
        {
            return !context.Atendimentos.Any() ? 0 + 1 : context.Atendimentos.OrderByDescending(o => o.Codigo).First().Codigo + 1;
        }

        //
        // GET: /Atendimentos/Criar

        public ActionResult Criar()
        {
            ViewBag.PossibleConvenios = context.Convenios;
            ViewBag.PossibleTiposAtendimentos = context.TiposAtendimentos;
            ViewBag.PossibleProcedimentos = context.Procedimentos;
            AtendimentoViewModel model = new AtendimentoViewModel();// = Carregar();
            model.Codigo = ProximoCodigo();

            return View(model);
        } 

        //
        // POST: /Atendimentos/Criar

        [HttpPost]
        public ActionResult Criar(AtendimentoViewModel atendimentoVM)
        {
            Atendimento atendimento = new Atendimento()
            {
                Codigo = atendimentoVM.Codigo
            };

            if (ModelState.IsValid)
            {
                context.Atendimentos.Add(atendimento);
                context.SaveChanges();
                return RedirectToAction(nameof(AtendimentosController.Indice));  
            }

            ViewBag.PossibleConvenios = context.Convenios;
            ViewBag.PossibleTiposAtendimentos = context.TiposAtendimentos;
            ViewBag.PossibleProcedimentos = context.Procedimentos;
            return View(atendimentoVM);
        }
        
        //
        // GET: /Atendimentos/Editar/5
 
        public ActionResult Editar(int id)
        {
            Atendimento atendimento = context.Atendimentos.Single(x => x.AtendimentoId == id);
            ViewBag.PossibleConvenios = context.Convenios;
            ViewBag.PossibleTiposAtendimentos = context.TiposAtendimentos;
            ViewBag.PossibleProcedimentos = context.Procedimentos;

            AtendimentoViewModel atendimentoVM = new AtendimentoViewModel();
            return View(atendimentoVM);
        }

        //
        // POST: /Atendimentos/Editar/5

        [HttpPost]
        public ActionResult Editar(AtendimentoViewModel atendimentoVM)
        {
            Atendimento atendimento = new Atendimento()
            {
                Codigo = atendimentoVM.Codigo
            };

            if (ModelState.IsValid)
            {
                context.Entry(atendimento).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction(nameof(AtendimentosController.Indice));
            }
            ViewBag.PossibleConvenios = context.Convenios;
            ViewBag.PossibleTiposAtendimentos = context.TiposAtendimentos;
            ViewBag.PossibleProcedimentos = context.Procedimentos;
            return View(atendimentoVM);
        }

        //
        // GET: /Atendimentos/Excluir/5
 
        public ActionResult Excluir(int id)
        {
            Atendimento atendimento = context.Atendimentos.Single(x => x.AtendimentoId == id);
            return View(atendimento);
        }

        //
        // POST: /Atendimentos/Excluir/5

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExclusao(int id)
        {
            Atendimento atendimento = context.Atendimentos.Single(x => x.AtendimentoId == id);
            context.Atendimentos.Remove(atendimento);
            context.SaveChanges();
            return RedirectToAction(nameof(AtendimentosController.Indice));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
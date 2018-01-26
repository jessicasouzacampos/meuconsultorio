using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuConsultorio.Models;

namespace MeuConsultorio.Controllers
{   
    public class ProcedimentosController : Controller
    {
        private MeuConsultorioContext context = new MeuConsultorioContext();

        //
        // GET: /Procedimentos/

        public ViewResult Indice()
        {
            return View(context.Procedimentos.Include(procedimento => procedimento.TipoAtendimento).ToList());
        }

        //
        // GET: /Procedimentos/Detalhes/5

        public ViewResult Detalhes(int id)
        {
            Procedimento procedimento = context.Procedimentos.Single(x => x.ProcedimentoId == id);
            return View(procedimento);
        }

        //
        // GET: /Procedimentos/Criar

        public ActionResult Criar()
        {
            ViewBag.PossibleTiposAtendimentos = context.TiposAtendimentos;
            return View();
        } 

        //
        // POST: /Procedimentos/Criar

        [HttpPost]
        public ActionResult Criar(Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                context.Procedimentos.Add(procedimento);
                context.SaveChanges();
                return RedirectToAction(nameof(ProcedimentosController.Indice));  
            }

            ViewBag.PossibleTiposAtendimentos = context.TiposAtendimentos;
            return View(procedimento);
        }
        
        //
        // GET: /Procedimentos/Editar/5
 
        public ActionResult Editar(int id)
        {
            Procedimento procedimento = context.Procedimentos.Single(x => x.ProcedimentoId == id);
            ViewBag.PossibleTiposAtendimentos = context.TiposAtendimentos;
            return View(procedimento);
        }

        //
        // POST: /Procedimentos/Editar/5

        [HttpPost]
        public ActionResult Editar(Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                context.Entry(procedimento).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction(nameof(ProcedimentosController.Indice));
            }
            ViewBag.PossibleTiposAtendimentos = context.TiposAtendimentos;
            return View(procedimento);
        }

        //
        // GET: /Procedimentos/Excluir/5
 
        public ActionResult Excluir(int id)
        {
            Procedimento procedimento = context.Procedimentos.Single(x => x.ProcedimentoId == id);
            return View(procedimento);
        }

        //
        // POST: /Procedimentos/Excluir/5

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExclusao(int id)
        {
            Procedimento procedimento = context.Procedimentos.Single(x => x.ProcedimentoId == id);
            context.Procedimentos.Remove(procedimento);
            context.SaveChanges();
            return RedirectToAction(nameof(ProcedimentosController.Indice));
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
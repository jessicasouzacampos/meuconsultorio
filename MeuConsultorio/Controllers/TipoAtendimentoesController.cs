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
    public class TipoAtendimentoesController : Controller
    {
        private MeuConsultorioContext context = new MeuConsultorioContext();

        //
        // GET: /TipoAtendimentoes/

        public ViewResult Indice()
        {
            return View(context.TipoAtendimentoes.Include(tipoatendimento => tipoatendimento.Procedimentos).ToList());
        }

        //
        // GET: /TipoAtendimentoes/Detalhes/5

        public ViewResult Detalhes(int id)
        {
            TipoAtendimento tipoatendimento = context.TipoAtendimentoes.Single(x => x.TipoAtendimentoId == id);
            return View(tipoatendimento);
        }

        //
        // GET: /TipoAtendimentoes/Criar

        public ActionResult Criar()
        {
            return View();
        } 

        //
        // POST: /TipoAtendimentoes/Criar

        [HttpPost]
        public ActionResult Criar(TipoAtendimento tipoatendimento)
        {
            if (ModelState.IsValid)
            {
                context.TipoAtendimentoes.Add(tipoatendimento);
                context.SaveChanges();
                return RedirectToAction(nameof(TipoAtendimentoesController.Indice));  
            }

            return View(tipoatendimento);
        }
        
        //
        // GET: /TipoAtendimentoes/Editar/5
 
        public ActionResult Editar(int id)
        {
            TipoAtendimento tipoatendimento = context.TipoAtendimentoes.Single(x => x.TipoAtendimentoId == id);
            return View(tipoatendimento);
        }

        //
        // POST: /TipoAtendimentoes/Editar/5

        [HttpPost]
        public ActionResult Editar(TipoAtendimento tipoatendimento)
        {
            if (ModelState.IsValid)
            {
                context.Entry(tipoatendimento).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction(nameof(TipoAtendimentoesController.Indice));
            }
            return View(tipoatendimento);
        }

        //
        // GET: /TipoAtendimentoes/Excluir/5
 
        public ActionResult Excluir(int id)
        {
            TipoAtendimento tipoatendimento = context.TipoAtendimentoes.Single(x => x.TipoAtendimentoId == id);
            return View(tipoatendimento);
        }

        //
        // POST: /TipoAtendimentoes/Excluir/5

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExclusao(int id)
        {
            TipoAtendimento tipoatendimento = context.TipoAtendimentoes.Single(x => x.TipoAtendimentoId == id);
            context.TipoAtendimentoes.Remove(tipoatendimento);
            context.SaveChanges();
            return RedirectToAction(nameof(TipoAtendimentoesController.Indice));
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
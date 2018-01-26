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
    public class ConveniosController : Controller
    {
        private MeuConsultorioContext context = new MeuConsultorioContext();

        //
        // GET: /Convenios/

        public ViewResult Indice()
        {
            return View(context.Convenios.ToList());
        }

        //
        // GET: /Convenios/Detalhes/5

        public ViewResult Detalhes(int id)
        {
            Convenio convenio = context.Convenios.Single(x => x.ConvenioId == id);
            return View(convenio);
        }

        //
        // GET: /Convenios/Criar

        public ActionResult Criar()
        {
            return View();
        } 

        //
        // POST: /Convenios/Criar

        [HttpPost]
        public ActionResult Criar(Convenio convenio)
        {
            if (ModelState.IsValid)
            {
                context.Convenios.Add(convenio);
                context.SaveChanges();
                return RedirectToAction(nameof(ConveniosController.Indice));  
            }

            return View(convenio);
        }
        
        //
        // GET: /Convenios/Editar/5
 
        public ActionResult Editar(int id)
        {
            Convenio convenio = context.Convenios.Single(x => x.ConvenioId == id);
            return View(convenio);
        }

        //
        // POST: /Convenios/Editar/5

        [HttpPost]
        public ActionResult Editar(Convenio convenio)
        {
            if (ModelState.IsValid)
            {
                context.Entry(convenio).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction(nameof(ConveniosController.Indice));
            }
            return View(convenio);
        }

        //
        // GET: /Convenios/Excluir/5
 
        public ActionResult Excluir(int id)
        {
            Convenio convenio = context.Convenios.Single(x => x.ConvenioId == id);
            return View(convenio);
        }

        //
        // POST: /Convenios/Excluir/5

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExclusao(int id)
        {
            Convenio convenio = context.Convenios.Single(x => x.ConvenioId == id);
            context.Convenios.Remove(convenio);
            context.SaveChanges();
            return RedirectToAction(nameof(ConveniosController.Indice));
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
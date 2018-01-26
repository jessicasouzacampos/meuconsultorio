using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeuConsultorio.Models;

namespace MeuConsultorio.Views
{
    public class ProcedimentoConveniosController : Controller
    {
        private MeuConsultorioContext db = new MeuConsultorioContext();

        // GET: ProcedimentoConvenios
        public ActionResult Index()
        {
            var procedimentosConvenios = db.ProcedimentosConvenios.Include(p => p.Convenio).Include(p => p.Procedimento);
            return View(procedimentosConvenios.ToList());
        }

        // GET: ProcedimentoConvenios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedimentoConvenio procedimentoConvenio = db.ProcedimentosConvenios.Find(id);
            if (procedimentoConvenio == null)
            {
                return HttpNotFound();
            }
            return View(procedimentoConvenio);
        }

        // GET: ProcedimentoConvenios/Create
        public ActionResult Create()
        {
            ViewBag.ConvenioId = new SelectList(db.Convenios, "ConvenioId", "Descricao");
            ViewBag.ProcedimentoId = new SelectList(db.Procedimentos, "ProcedimentoId", "Descricao");
            return View();
        }

        // POST: ProcedimentoConvenios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProcedimentoConvenioId,Codigo,ProcedimentoId,ConvenioId,Valor")] ProcedimentoConvenio procedimentoConvenio)
        {
            if (ModelState.IsValid)
            {
                db.ProcedimentosConvenios.Add(procedimentoConvenio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConvenioId = new SelectList(db.Convenios, "ConvenioId", "Descricao", procedimentoConvenio.ConvenioId);
            ViewBag.ProcedimentoId = new SelectList(db.Procedimentos, "ProcedimentoId", "Descricao", procedimentoConvenio.ProcedimentoId);
            return View(procedimentoConvenio);
        }

        // GET: ProcedimentoConvenios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedimentoConvenio procedimentoConvenio = db.ProcedimentosConvenios.Find(id);
            if (procedimentoConvenio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConvenioId = new SelectList(db.Convenios, "ConvenioId", "Descricao", procedimentoConvenio.ConvenioId);
            ViewBag.ProcedimentoId = new SelectList(db.Procedimentos, "ProcedimentoId", "Descricao", procedimentoConvenio.ProcedimentoId);
            return View(procedimentoConvenio);
        }

        // POST: ProcedimentoConvenios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProcedimentoConvenioId,Codigo,ProcedimentoId,ConvenioId,Valor")] ProcedimentoConvenio procedimentoConvenio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedimentoConvenio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConvenioId = new SelectList(db.Convenios, "ConvenioId", "Descricao", procedimentoConvenio.ConvenioId);
            ViewBag.ProcedimentoId = new SelectList(db.Procedimentos, "ProcedimentoId", "Descricao", procedimentoConvenio.ProcedimentoId);
            return View(procedimentoConvenio);
        }

        // GET: ProcedimentoConvenios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedimentoConvenio procedimentoConvenio = db.ProcedimentosConvenios.Find(id);
            if (procedimentoConvenio == null)
            {
                return HttpNotFound();
            }
            return View(procedimentoConvenio);
        }

        // POST: ProcedimentoConvenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcedimentoConvenio procedimentoConvenio = db.ProcedimentosConvenios.Find(id);
            db.ProcedimentosConvenios.Remove(procedimentoConvenio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

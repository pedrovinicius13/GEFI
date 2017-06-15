using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projeto_FILA.Models;
using PagedList;

namespace Areas.Administracao.Controllers
{
    public class ServicoController : Controller
    {
        private ContextoEF db = new ContextoEF();

        // GET: Servico
        public ActionResult Consultar(int? pagina, string NomeF = null)
        {
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            var ServicoP = new Object();

            if (!String.IsNullOrEmpty(NomeF))
            {
                ServicoP = db.Servicoes
                    .Where(r => r.NomeServico.ToUpper().Contains(NomeF.ToUpper()))
                    .OrderBy(r => r.NomeServico)
                    .ToPagedList(numeroPagina, tamanhoPagina);
            }
            else
            {
                ServicoP = db.Servicoes.OrderBy(p => p.NomeServico).ToPagedList(numeroPagina, tamanhoPagina);
            }
            return View("Index", ServicoP);
        }

        public ActionResult Index(string ordenacao, int? pagina)
        {
            ViewBag.OrdenacaoAtual = ordenacao;
            ViewBag.nomeParam = string.IsNullOrEmpty(ordenacao) ? "Nome_Desc" : "";
            var ServicoOr = from c in db.Servicoes select c;
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            switch (ordenacao)
            {
                case "Nome_Desc":
                    ServicoOr = ServicoOr.OrderByDescending(s => s.NomeServico);
                    break;
                default:
                    ServicoOr = ServicoOr.OrderBy(s => s.NomeServico);
                    break;
            }
            return View(ServicoOr.ToPagedList(numeroPagina, tamanhoPagina));
            //return View(db.Servicoes.OrderBy(p => p.NomeServico).ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Servico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicoes.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // GET: Servico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicoID,NomeServico")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                db.Servicoes.Add(servico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servico);
        }

        // GET: Servico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicoes.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // POST: Servico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicoID,NomeServico")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servico);
        }

        // GET: Servico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicoes.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // POST: Servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servico servico = db.Servicoes.Find(id);
            db.Servicoes.Remove(servico);
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

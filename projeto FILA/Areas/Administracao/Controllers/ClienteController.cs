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
    public class ClienteController : Controller
    {
        private ContextoEF db = new ContextoEF();

        // GET: Cliente
        public ActionResult Consultar(int? pagina, string NomeF = null)
        {
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            var ClienteP = new Object();

            if (!String.IsNullOrEmpty(NomeF))
            {
                ClienteP = db.Clientes
                    .Where(r => r.NomeCliente.ToUpper().Contains(NomeF.ToUpper()))
                    .OrderBy(r => r.NomeCliente)
                    .ToPagedList(numeroPagina, tamanhoPagina);
            }
            else
            {
                ClienteP = db.Clientes.OrderBy(p => p.NomeCliente).ToPagedList(numeroPagina, tamanhoPagina);
            }
            return View("Index", ClienteP);
        }


        public ActionResult Index(string ordenacao, int? pagina)

        {
            ViewBag.OrdenacaoAtual = ordenacao;
            ViewBag.nomeParam = string.IsNullOrEmpty(ordenacao) ? "Nome_Desc" : "";
            var clientesOr = from c in db.Clientes select c;
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            switch(ordenacao)
            {
                case "Nome_Desc":
                    clientesOr = clientesOr.OrderByDescending(s => s.NomeCliente);
                    break;
                default:
                    clientesOr = clientesOr.OrderBy(s => s.NomeCliente);
                    break;                      
            }
            return View(clientesOr.ToPagedList(numeroPagina, tamanhoPagina));

            //return View(db.Clientes.OrderBy(p => p.NomeCliente).ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,NomeCliente,CPF,Celular")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,NomeCliente,CPF,Celular")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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

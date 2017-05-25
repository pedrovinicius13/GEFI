using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projeto_FILA.Models;

namespace projeto_FILA.Controllers
{
    public class FilaController : Controller
    {
        private ContextoEF db = new ContextoEF();

        // GET: Fila
        public ActionResult Index()
        {
            var filas = db.Filas.Include(f => f.Cliente).Include(f => f.Funcionario).Include(f => f.Servico);
            return View(filas.ToList());
        }


        public ActionResult ListarPorFila(int TipoFilaId)
        {
            Situacao sa = (Situacao)TipoFilaId; ;

            var filas = db.Filas.Include(f => f.Cliente).Include(f => f.Funcionario).Include(f => f.Servico);
            return View(filas.Where(f => f.Situacao == sa).ToList());

         }


        public ActionResult OrdenacaoFila(int TipoId1, int TipoId2)
        {
            Situacao sa = (Situacao)TipoId1;
            Situacao sa2 = (Situacao)TipoId2;
            var Filas = db.Filas.Include(o => o.Cliente).Include(o => o.Funcionario);
            return View(Filas.Where(o => o.Situacao == sa || o.Situacao == sa2).OrderBy(o => o.FilaID).ToList());
        }

        // GET: Fila/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fila fila = db.Filas.Find(id);
            if (fila == null)
            {
                return HttpNotFound();
            }
            return View(fila);
        }

        // GET: Fila/Create
        public ActionResult Create()
        {
            ViewBag.Clientes = db.Clientes.ToList();
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "NomeCliente");
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario");
            ViewBag.ServicoID = new SelectList(db.Servicoes, "ServicoID", "NomeServico");
            return View();
        }

        // POST: Fila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilaID,Situacao,ClienteID,FuncionarioID,ServicoID")] Fila fila)
        {
            if (ModelState.IsValid)
            {
                db.Filas.Add(fila);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "NomeCliente", fila.ClienteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario", fila.FuncionarioID);
            ViewBag.ServicoID = new SelectList(db.Servicoes, "ServicoID", "NomeServico", fila.ServicoID);
            return View(fila);
        }

        // GET: Fila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fila fila = db.Filas.Find(id);
            if (fila == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "NomeCliente", fila.ClienteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario", fila.FuncionarioID);
            ViewBag.ServicoID = new SelectList(db.Servicoes, "ServicoID", "NomeServico", fila.ServicoID);
            return View(fila);
        }

        // POST: Fila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilaID,Situacao,ClienteID,FuncionarioID,ServicoID")] Fila fila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "NomeCliente", fila.ClienteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario", fila.FuncionarioID);
            ViewBag.ServicoID = new SelectList(db.Servicoes, "ServicoID", "NomeServico", fila.ServicoID);
            return View(fila);
        }

        // GET: Fila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fila fila = db.Filas.Find(id);
            if (fila == null)
            {
                return HttpNotFound();
            }
            return View(fila);
        }

        // POST: Fila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fila fila = db.Filas.Find(id);
            db.Filas.Remove(fila);
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

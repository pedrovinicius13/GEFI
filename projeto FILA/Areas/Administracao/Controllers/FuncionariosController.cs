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
    public class FuncionariosController : Controller
    {
        private ContextoEF db = new ContextoEF();

        // GET: Funcionarios

            public ActionResult Consultar(int? pagina, string NomeF = null)
        {
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            var FuncionarioP = new Object();

            if(!String.IsNullOrEmpty(NomeF))
            {
                FuncionarioP =db.Funcionarios
                    .Where(r => r.NomeFuncionario.ToUpper().Contains(NomeF.ToUpper()))
                    .OrderBy(r => r.NomeFuncionario)
                    .ToPagedList(numeroPagina, tamanhoPagina);
            }
            else
            {
                FuncionarioP = db.Funcionarios.OrderBy(p => p.NomeFuncionario).ToPagedList(numeroPagina, tamanhoPagina);
            }
            return View("Index", FuncionarioP);
        }

        public ActionResult Index(string ordenacao, int? pagina)
        {
            ViewBag.OrdenacaoAtual = ordenacao;
            ViewBag.nomeParam = string.IsNullOrEmpty(ordenacao) ? "Nome_Desc" : "";
            var FuncionarioOr = from c in db.Funcionarios select c;
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            switch (ordenacao)
            {
                case "Nome_Desc":
                    FuncionarioOr = FuncionarioOr.OrderByDescending(s => s.NomeFuncionario);
                    break;
                default:
                    FuncionarioOr = FuncionarioOr.OrderBy(s => s.NomeFuncionario);
                    break;
            }
            return View(FuncionarioOr.ToPagedList(numeroPagina, tamanhoPagina));
            //return View(db.Funcionarios.OrderBy(p => p.NomeFuncionario).ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FuncionarioID,NomeFuncionario")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuncionarioID,NomeFuncionario")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
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

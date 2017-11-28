using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TRABALHOMVC.Models;

namespace TRABALHOMVC.Controllers
{
    public class VendasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Vendas
        public ActionResult Index()
        {
            var vendas = db.vendas.Include(v => v.cliente).Include(v => v.item);
            return View(vendas.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            ViewBag.clienteId = new SelectList(db.clientes, "id", "nome");
            ViewBag.itemId = new SelectList(db.itens, "id", "descricao");
            return View();
        }

        // POST: Vendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,clienteId,itemId,data")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.vendas.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clienteId = new SelectList(db.clientes, "id", "nome", venda.clienteId);
            ViewBag.itemId = new SelectList(db.itens, "id", "descricao", venda.itemId);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.clienteId = new SelectList(db.clientes, "id", "nome", venda.clienteId);
            ViewBag.itemId = new SelectList(db.itens, "id", "descricao", venda.itemId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,clienteId,itemId,data")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clienteId = new SelectList(db.clientes, "id", "nome", venda.clienteId);
            ViewBag.itemId = new SelectList(db.itens, "id", "descricao", venda.itemId);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.vendas.Find(id);
            db.vendas.Remove(venda);
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

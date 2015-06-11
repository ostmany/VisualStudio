using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SysVYC.Models;

namespace SysVYC.Controllers
{
    public class ClientesController : Controller
    {
        private SVYC db = new SVYC();

        // GET: Clientes
        public ActionResult Index()
        {
            if (Session["IDUSUARIO"] != null)
            {
                var cLIENTE = db.CLIENTE.Include(c => c.EMPRESA).Include(c => c.TIPOCLIENTE);
                return View(cLIENTE.ToList());
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CLIENTE cLIENTE = db.CLIENTE.Find(id);
                if (cLIENTE == null)
                {
                    return HttpNotFound();
                }
                return View(cLIENTE);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            if (Session["IDUSUARIO"] != null)
            {
                ViewBag.IDEMPRESA = new SelectList(db.EMPRESA, "IDEMPRESA", "NOMBREEMPRESA");
                ViewBag.IDTIPOCLIENTE = new SelectList(db.TIPOCLIENTE, "IDTIPOCLIENTE", "TIPOCLIENTE1");
                return View();
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCLIENTE,IDTIPOCLIENTE,IDEMPRESA,NOMBRECLIENTE,APELLIDOCLIENTE,DUICLIENTE,NITCLIENTE,DIRECCIONCLIENTE,TELEFONOCLIENTE,EMAILCLIENTE")] CLIENTE cLIENTE)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.CLIENTE.Add(cLIENTE);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IDEMPRESA = new SelectList(db.EMPRESA, "IDEMPRESA", "NOMBREEMPRESA", cLIENTE.IDEMPRESA);
                ViewBag.IDTIPOCLIENTE = new SelectList(db.TIPOCLIENTE, "IDTIPOCLIENTE", "TIPOCLIENTE1", cLIENTE.IDTIPOCLIENTE);
                return View(cLIENTE);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CLIENTE cLIENTE = db.CLIENTE.Find(id);
                if (cLIENTE == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IDEMPRESA = new SelectList(db.EMPRESA, "IDEMPRESA", "NOMBREEMPRESA", cLIENTE.IDEMPRESA);
                ViewBag.IDTIPOCLIENTE = new SelectList(db.TIPOCLIENTE, "IDTIPOCLIENTE", "TIPOCLIENTE1", cLIENTE.IDTIPOCLIENTE);
                return View(cLIENTE);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCLIENTE,IDTIPOCLIENTE,IDEMPRESA,NOMBRECLIENTE,APELLIDOCLIENTE,DUICLIENTE,NITCLIENTE,DIRECCIONCLIENTE,TELEFONOCLIENTE,EMAILCLIENTE")] CLIENTE cLIENTE)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cLIENTE).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDEMPRESA = new SelectList(db.EMPRESA, "IDEMPRESA", "NOMBREEMPRESA", cLIENTE.IDEMPRESA);
                ViewBag.IDTIPOCLIENTE = new SelectList(db.TIPOCLIENTE, "IDTIPOCLIENTE", "TIPOCLIENTE1", cLIENTE.IDTIPOCLIENTE);
                return View(cLIENTE);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CLIENTE cLIENTE = db.CLIENTE.Find(id);
                if (cLIENTE == null)
                {
                    return HttpNotFound();
                }
                return View(cLIENTE);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                CLIENTE cLIENTE = db.CLIENTE.Find(id);
                db.CLIENTE.Remove(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Index");
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

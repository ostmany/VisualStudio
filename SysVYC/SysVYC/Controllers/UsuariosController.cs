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
    public class UsuariosController : Controller
    {
        private SVYC db = new SVYC();

        // GET: Usuarios
        public ActionResult Index()
        {
            if (Session["IDUSUARIO"] != null)
            {
                var uSUARIO = db.USUARIO.Include(u => u.EMPLEADO).Include(u => u.TIPOUSUARIO);
                return View(uSUARIO.ToList());
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                USUARIO uSUARIO = db.USUARIO.Find(id);
                if (uSUARIO == null)
                {
                    return HttpNotFound();
                }
                return View(uSUARIO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            if (Session["IDUSUARIO"] != null)
            {
                ViewBag.IDEMPLEADO = new SelectList(db.EMPLEADO, "IDEMPLEADO", "NOMBREEMPLEADO");
                ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "IDTIPOUSUARIO", "TIPOUSUARIO1");
                return View();
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUSUARIO,IDEMPLEADO,IDTIPOUSUARIO,USERNAME,PASSWORD")] USUARIO uSUARIO)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.USUARIO.Add(uSUARIO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IDEMPLEADO = new SelectList(db.EMPLEADO, "IDEMPLEADO", "NOMBREEMPLEADO", uSUARIO.IDEMPLEADO);
                ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "IDTIPOUSUARIO", "TIPOUSUARIO1", uSUARIO.IDTIPOUSUARIO);
                return View(uSUARIO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                USUARIO uSUARIO = db.USUARIO.Find(id);
                if (uSUARIO == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IDEMPLEADO = new SelectList(db.EMPLEADO, "IDEMPLEADO", "NOMBREEMPLEADO", uSUARIO.IDEMPLEADO);
                ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "IDTIPOUSUARIO", "TIPOUSUARIO1", uSUARIO.IDTIPOUSUARIO);
                return View(uSUARIO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUSUARIO,IDEMPLEADO,IDTIPOUSUARIO,USERNAME,PASSWORD")] USUARIO uSUARIO)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(uSUARIO).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDEMPLEADO = new SelectList(db.EMPLEADO, "IDEMPLEADO", "NOMBREEMPLEADO", uSUARIO.IDEMPLEADO);
                ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "IDTIPOUSUARIO", "TIPOUSUARIO1", uSUARIO.IDTIPOUSUARIO);
                return View(uSUARIO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                USUARIO uSUARIO = db.USUARIO.Find(id);
                if (uSUARIO == null)
                {
                    return HttpNotFound();
                }
                return View(uSUARIO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                USUARIO uSUARIO = db.USUARIO.Find(id);
                db.USUARIO.Remove(uSUARIO);
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

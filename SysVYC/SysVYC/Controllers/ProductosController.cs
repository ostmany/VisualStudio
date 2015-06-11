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
    public class ProductosController : Controller
    {
        private SVYC db = new SVYC();

        // GET: Productos
        public ActionResult Index()
        {
            if (Session["IDUSUARIO"] != null)
            {
                var pRODUCTO = db.PRODUCTO.Include(p => p.MARCA);
                return View(pRODUCTO.ToList());
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Productos/Details/5
        public ActionResult Details(long? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
                if (pRODUCTO == null)
                {
                    return HttpNotFound();
                }
                return View(pRODUCTO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            if (Session["IDUSUARIO"] != null)
            {
                ViewBag.IDMARCA = new SelectList(db.MARCA, "IDMARCA", "NOMBREMARCA");
                return View();
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPRODUCTO,IDMARCA,NOMBREPRODUCTO,DESCRIPCIONPRODUCTO,MODELOPRODUCTO,COSTOPRODUCTO,PRECIOPRODUCTO")] PRODUCTO pRODUCTO)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.PRODUCTO.Add(pRODUCTO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IDMARCA = new SelectList(db.MARCA, "IDMARCA", "NOMBREMARCA", pRODUCTO.IDMARCA);
                return View(pRODUCTO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
                if (pRODUCTO == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IDMARCA = new SelectList(db.MARCA, "IDMARCA", "NOMBREMARCA", pRODUCTO.IDMARCA);
                return View(pRODUCTO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPRODUCTO,IDMARCA,NOMBREPRODUCTO,DESCRIPCIONPRODUCTO,MODELOPRODUCTO,COSTOPRODUCTO,PRECIOPRODUCTO")] PRODUCTO pRODUCTO)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(pRODUCTO).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDMARCA = new SelectList(db.MARCA, "IDMARCA", "NOMBREMARCA", pRODUCTO.IDMARCA);
                return View(pRODUCTO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
                if (pRODUCTO == null)
                {
                    return HttpNotFound();
                }
                return View(pRODUCTO);
            }
            else
                return RedirectToAction("Index", "Index");
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
                db.PRODUCTO.Remove(pRODUCTO);
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

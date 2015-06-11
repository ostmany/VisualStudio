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
    public class EmpleadosController : Controller
    {
        private SVYC db = new SVYC();

        // GET: Empleados
        public ActionResult Index()
        {
            if (Session["IDUSUARIO"] != null)
                return View(db.EMPLEADO.ToList());
            else
                return RedirectToAction("Index","Index");   
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
                if (eMPLEADO == null)
                {
                    return HttpNotFound();
                }
                return View(eMPLEADO);
            }
            else
                return RedirectToAction("Index", "Index");   
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            if (Session["IDUSUARIO"] != null) 
                return View();
            else
                return RedirectToAction("Index","Index");   
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEMPLEADO,NOMBREEMPLEADO,APELLIDOEMPLEADO,DUIEMPLEADO,NITEMPLEADO,DIRECCIONEMPLEADO,TELEFONOEMPLEADO,EMAILEMPLEADO")] EMPLEADO eMPLEADO)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.EMPLEADO.Add(eMPLEADO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(eMPLEADO);
            }
            else
                return RedirectToAction("Index", "Index");   
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
                if (eMPLEADO == null)
                {
                    return HttpNotFound();
                }
                return View(eMPLEADO);
            }
            else
                return RedirectToAction("Index", "Index");  
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEMPLEADO,NOMBREEMPLEADO,APELLIDOEMPLEADO,DUIEMPLEADO,NITEMPLEADO,DIRECCIONEMPLEADO,TELEFONOEMPLEADO,EMAILEMPLEADO")] EMPLEADO eMPLEADO)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(eMPLEADO).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(eMPLEADO);
            }
            else
                return RedirectToAction("Index", "Index");  
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
                if (eMPLEADO == null)
                {
                    return HttpNotFound();
                }
                return View(eMPLEADO);
            }
            else
                return RedirectToAction("Index", "Index");  
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IDUSUARIO"] != null)
            {
                EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
                db.EMPLEADO.Remove(eMPLEADO);
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

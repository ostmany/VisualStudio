using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysVYC.Models;

namespace SysVYC.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(USUARIO u)
        {
            if(ModelState.IsValid)
            {
                //byte[] decryted = Convert.FromBase64String();
                using(SVYC db = new SVYC())
                {
                    var v = db.USUARIO.Where(a => a.USERNAME.Equals(u.USERNAME) && a.PASSWORD.Equals(u.PASSWORD)).FirstOrDefault();
                    if(v != null)
                    {
                        Session["IDUSUARIO"] = v.IDUSUARIO.ToString();
                        Session["IDTIPOUSUARIO"] = v.IDTIPOUSUARIO.ToString();
                        if(Session["IDTIPOUSUARIO"].ToString().Equals("1"))
                            return RedirectToAction("Principal");
                        else
                            return RedirectToAction("Negocio");
                    }
                }

            }
            return View(u);
        }

        public ActionResult Principal()
        {
            if (Session["IDUSUARIO"] != null)
                return View();
            else
                return RedirectToAction("Index");   
        }

        public ActionResult Negocio()
        {
            if (Session["IDUSUARIO"] != null)
                return View();
            else
                return RedirectToAction("Index");
        }

        public ActionResult CerrarSession()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        
    }
}
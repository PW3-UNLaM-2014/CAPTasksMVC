using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;

namespace CAPTasksMVC.Controllers
{
    public class HomeController : Controller
    {
        private CAPTasksEntities cap = new CAPTasksEntities();
        
        //
        // GET: /Home/

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult CrearCarpeta()
        {
            return View();
        }

        public ActionResult CrearTarea()
        {
            ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
            ViewBag.IdUsuario = new SelectList(cap.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        public ActionResult ModificarTarea()
        {
            return View();
        }

        public ActionResult EliminarTarea()
        {
            return View();
        }
    }
}

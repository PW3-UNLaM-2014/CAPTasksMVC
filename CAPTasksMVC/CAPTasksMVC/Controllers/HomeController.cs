using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;
using CAPTasksMVC.Servicios;

namespace CAPTasksMVC.Controllers
{
    /**
     * Autorize bloquea el ingreso si no se esta logueado.
     * Quedara comentado hasta la version final.
     * TODO: Descomentar para la entrega.
     * */
    //[Authorize]

    public class HomeController : Controller
    {
        CAPTasksEntities cap = new CAPTasksEntities();

        CarpetaTareaServicios cts = new CarpetaTareaServicios();

        public ActionResult Home()
        {
            CarpetaTareaModel ctm = cts.CrearListas();

            return View(ctm);
        }
    }
}

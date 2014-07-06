using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;
using CAPTasksMVC.Servicios;
using System.Web.Security;

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
            int idUsuario = Convert.ToInt16(this.Session["IdUsuario"]);
            CarpetaTareaModel ctm = cts.CrearListas(idUsuario);

            return View(ctm);
        }

        [HttpPost]
        public ActionResult ListarTodasLasTareas()
        {
            bool estado = bool.Parse(Request.Form.GetValues("ckbFinalizadas")[0]);

            if (estado == true)
            {
                int idUsuario = Convert.ToInt16(this.Session["IdUsuario"]);
                CarpetaTareaModel ctm = cts.ListarTodasLasTareas(idUsuario);
                Request.Form.["ckbFinalizadas"] = "on";
                return View("Home", ctm);
            }
            else
            {
                return RedirectToAction("Home");            
            }
        }

        public ActionResult ListarTareasPorCarpeta(int idCarpeta)
        {
            int idUsuario = Convert.ToInt16(this.Session["IdUsuario"]);
            CarpetaTareaModel ctm = cts.ListarTareasPorCarpeta(idCarpeta, idUsuario);
            return View("Home", ctm);
        }
    }
}

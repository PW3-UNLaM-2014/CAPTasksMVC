using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;
using CAPTasksMVC.Servicios;

namespace CAPTasksMVC.Controllers
{
    public class CarpetasController : Controller
    {
        CarpetasServicios cs = new CarpetasServicios();

        public ActionResult CrearCarpeta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCarpeta(Carpetas carpeta)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    cs.CrearCarpeta(carpeta);
                    return RedirectToAction("Home", "Home");
                }
                catch (Exception ex)
                {
                    ClientException.LogException(ex, "Error al crear la carpeta");
                    return RedirectToAction("Error", "Shared");
                }
            }
            else
            {
                ModelState.AddModelError("", "No se puede crear la carpeta, intentelo nuevamente");
                return View(carpeta);
            }
        }
    }
}

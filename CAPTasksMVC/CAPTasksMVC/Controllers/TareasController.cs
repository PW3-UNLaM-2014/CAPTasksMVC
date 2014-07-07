using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;
using CAPTasksMVC.Servicios;

namespace CAPTasksMVC.Controllers
{
    public class TareasController : Controller
    {
        TareasServicios ts = new TareasServicios();
        CarpetasServicios cs = new CarpetasServicios();

        public ActionResult CrearTarea()
        {
            int idUsuario = Convert.ToInt16(this.Session["IdUsuario"]);
            var usuario = cs.TraerCarpetasUsuario(idUsuario);
            ViewBag.IdCarpeta = new SelectList(usuario, "IdCarpeta", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult CrearTarea(int idUsuario, string nombre, string descripcion, int idCarpeta, DateTime fechaFin, int prioridad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ts.CrearTarea(idUsuario, nombre, descripcion, idCarpeta, fechaFin, prioridad);
                    return RedirectToAction("Home","Home");
                }
                catch (Exception ex)
                {
                    ClientException.LogException(ex, "Error al crear la tarea");
                    return RedirectToAction("Error", "Shared");
                }
            }
            else
            {
                ModelState.AddModelError("", "No se puede crear la tarea, intentelo nuevamente");
                return View();
            }
        }

        public ActionResult ModificarTarea(int idTarea)
        {
            int idUsuario = Convert.ToInt16(this.Session["IdUsuario"]);
            Tareas tarea = ts.ObtenerTareaModificar(idTarea);
            var usuario = cs.TraerCarpetasUsuario(idUsuario);
            ViewBag.IdCarpeta = new SelectList(usuario, "IdCarpeta", "Nombre", tarea.IdCarpeta);
            return View(tarea);
        }

        [HttpPost]
        public ActionResult ModificarTarea(int idTarea, int idCarpeta, string nombre, string descripcion, DateTime fechaFin, int prioridad)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    ts.ModificarTarea(idTarea, idCarpeta, nombre, descripcion, fechaFin, prioridad);
                    return RedirectToAction("Home","Home");
                }
                catch (Exception ex)
                {
                    ClientException.LogException(ex, "Error al modificar la tarea");
                    return RedirectToAction("Error", "Shared");
                }
            }

            else
            {
                ModelState.AddModelError("", "No se puede modificar la tarea, intentelo nuevamente");
                return View();
            }
        }

        public ActionResult EliminarTarea(int idTarea)
        {
            Tareas tarea = ts.ObtenerTareaEliminar(idTarea);
            return View(tarea);
        }

        [HttpPost, ActionName("EliminarTarea")]
        public ActionResult Eliminar(int idTarea)
        {
            try
            {
                ts.EliminarTarea(idTarea);
                return RedirectToAction("Home","Home");
            }
            catch (Exception ex)
            {
                ClientException.LogException(ex, "Error al eliminar la tarea");
                return RedirectToAction("Error", "Shared");
            }
        }

        [HttpPost]
        public ActionResult CompletarTarea(int idTarea)
        {
            ts.CambiarEstadoTarea(idTarea);

            return RedirectToAction("Home","Home");
        }
    }
}

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
     * Autorize determina si se debe estar logueado o no.
     * */
    //[Authorize]

    public class HomeController : Controller
    {
        CAPTasksEntities cap = new CAPTasksEntities();

        CarpetasServicios cs = new CarpetasServicios();
        TareasServicios ts = new TareasServicios();

        public ActionResult Home()
        {
            var resultado = (from tareas in cap.Tareas select tareas).ToList();
            return View(resultado);
        }

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
                    return RedirectToAction("Home");
                }
                catch (Exception ex)
                {
                    ClientException.LogException(ex, "Error al crear la carpeta");
                    return RedirectToAction("Error", "Shared");
                }
            }
            else
            {
                ViewData["mensaje1"] = "Error al crear la carpeta";
                return View();
            }
        }


        public ActionResult CrearTarea()
        {
            ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
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
                    return RedirectToAction("Home");
                }
                catch (Exception ex)
                {
                    ClientException.LogException(ex, "Error al crear la tarea");
                    return RedirectToAction("Error", "Shared");
                }
            }
            else
            {
                ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
                ViewData["mensaje2"] = "Error al crear la tarea";
                return View();
            }
        }

        public ActionResult ModificarTarea(int idTarea)
        {
            Tareas tarea = ts.ObtenerTareaModificar(idTarea);
            ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
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
                    return RedirectToAction("Home");
                }
                catch (Exception ex)
                {
                    ClientException.LogException(ex, "Error al modificar la tarea");
                    return RedirectToAction("Error", "Shared");
                }
            }

            else
            {
                ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
                ViewData["mensaje3"] = "Error al modificar la tarea";
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
                return RedirectToAction("Home");
            }
            catch (Exception ex)
            {
                ClientException.LogException(ex, "Error al eliminar la tarea");
                return RedirectToAction("Error", "Shared");
            }
        }
    }
}

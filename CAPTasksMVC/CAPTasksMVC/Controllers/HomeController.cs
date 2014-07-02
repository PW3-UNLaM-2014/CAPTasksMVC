using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;
using CAPTasksMVC.Servicios;

namespace CAPTasksMVC.Controllers
{
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
                return View(carpeta);
        }


        public ActionResult CrearTarea()
        {
            ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Baja", Value = "0" });
            items.Add(new SelectListItem { Text = "Media", Value = "1" });
            items.Add(new SelectListItem { Text = "Alta", Value = "2" });
            items.Add(new SelectListItem { Text = "Urgente", Value = "3" });
            ViewBag.Prioridad = items;
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
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Baja", Value = "0" });
                items.Add(new SelectListItem { Text = "Media", Value = "1" });
                items.Add(new SelectListItem { Text = "Alta", Value = "2" });
                items.Add(new SelectListItem { Text = "Urgente", Value = "3" });
                ViewBag.Prioridad = items;
                return View();
            }
        }

        public ActionResult ModificarTarea(int idTarea)
        {
            Tareas tarea = cap.Tareas.Where(e => e.IdTarea == idTarea).FirstOrDefault();
            ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Baja", Value = "0" });
            items.Add(new SelectListItem { Text = "Media", Value = "1" });
            items.Add(new SelectListItem { Text = "Alta", Value = "2" });
            items.Add(new SelectListItem { Text = "Urgente", Value = "3" });
            ViewBag.Prioridad = items;
            return View(tarea);
        }

        [HttpPost]
        public ActionResult ModificarTarea(int idTarea,int idCarpeta, string nombre, string descripcion, DateTime fechaFin, int prioridad)
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
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Baja", Value = "0" });
                items.Add(new SelectListItem { Text = "Media", Value = "1" });
                items.Add(new SelectListItem { Text = "Alta", Value = "2" });
                items.Add(new SelectListItem { Text = "Urgente", Value = "3" });
                ViewBag.Prioridad = items;
                return View();
            }
        }

        public ActionResult EliminarTarea(int idTarea)
        {
            Tareas tarea = cap.Tareas.Single(e => e.IdTarea == idTarea);
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
            catch(Exception ex)
            {
                ClientException.LogException(ex, "Error al eliminar la tarea");
                return RedirectToAction("Error", "Shared");
            }
        }
    }
}

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
            //var carpetas = (from car in cap.Carpetas select car).ToList();
            var resultado = (from car in cap.Tareas select car).ToList();//modificar para que muestre solo las del usuario logueado
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
                    //Carpetas miCarpeta = new Carpetas();
                    //miCarpeta.IdUsuario = idUsuario;
                    //miCarpeta.Nombre = nombre;
                    //miCarpeta.Descripcion = descripcion;
                    //cap.AddToCarpetas(miCarpeta);
                    cap.AddToCarpetas(carpeta);
                    cap.SaveChanges();
                    return RedirectToAction("Home");
                }
                catch (Exception ex)
                {
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
                    Tareas miTarea = new Tareas();
                    miTarea.IdUsuario = idUsuario;
                    miTarea.Nombre = nombre;
                    miTarea.Descripcion = descripcion;
                    miTarea.FechaFin = fechaFin;
                    miTarea.IdCarpeta = idCarpeta;
                    miTarea.Prioridad = Convert.ToInt16(prioridad);
                    miTarea.Estado = 1;
                    cap.Tareas.AddObject(miTarea);
                    cap.SaveChanges();
                    return RedirectToAction("Home");
                }
                catch(Exception ex)
                {
                    return RedirectToAction("Error", "Shared");
                }
            }
            else
                return View();
        }

        public ActionResult ModificarTarea(int idTarea)
        {
            Tareas tarea = cap.Tareas.Where(e => e.IdTarea == idTarea).FirstOrDefault();
            ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
            return View(tarea);

        }

        [HttpPost]
        public ActionResult ModificarTarea()
        {
            
            return View();

        }

        public ActionResult EliminarTarea(int idTarea)
        {
            Tareas tarea = cap.Tareas.Single(e => e.IdTarea == idTarea);
            return View(tarea);
        }

        [HttpPost, ActionName("EliminarTarea")]
        public ActionResult Eliminar(int idTarea)
        {
            var baja = (from e in cap.Tareas
                        where e.IdTarea==idTarea
                        select e).Single();

            cap.Tareas.DeleteObject(baja);
            cap.SaveChanges();
            return RedirectToAction("Home");
        }
    }
}

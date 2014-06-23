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
            var carpetas = (from car in cap.Carpetas select car).ToList();
            return View(carpetas);
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
                    return View();
                }
            }
            else
                return View(carpeta);
        }


        public ActionResult CrearTarea()
        {
            ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult CrearTarea(Tareas tarea)
        {
            if (ModelState.IsValid)
            {
                //Tareas miTarea = new Tareas();
                //miTarea.IdUsuario = idUsuario;
                //miTarea.Nombre = nombre;
                //miTarea.Descripcion = descripcion;
                //miTarea.FechaFin = DateTime.Now;
                //miTarea.IdCarpeta = idcarpeta;
                //miTarea.Prioridad = 1;
                //miTarea.Estado = 1;
                //cap.AddToCarpetas(tarea);
                //cap.SaveChanges();
                return RedirectToAction("Home");
            }
            else
                return View(tarea);
        }

        public ActionResult ModificarTarea()
        {
            ViewBag.IdCarpeta = new SelectList(cap.Carpetas, "IdCarpeta", "Nombre");
            return View();

        }

        public ActionResult EliminarTarea()
        {
            return View();
        }
    }
}

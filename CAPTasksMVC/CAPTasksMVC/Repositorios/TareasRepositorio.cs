using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;

namespace CAPTasksMVC.Repositorios
{
    public class TareasRepositorio
    {
        CAPTasksEntities context = new CAPTasksEntities();
        public void CrearTarea(int idUsuario, string nombre, string descripcion, int idCarpeta, DateTime fechaFin, int prioridad)
        {
            Tareas miTarea = new Tareas();
            miTarea.IdUsuario = idUsuario;
            miTarea.Nombre = nombre;
            miTarea.Descripcion = descripcion;
            miTarea.FechaFin = fechaFin;
            miTarea.IdCarpeta = idCarpeta;
            miTarea.Prioridad = Convert.ToInt16(prioridad);
            miTarea.Estado = 1;
            context.Tareas.AddObject(miTarea);
            context.SaveChanges();
        }

        public void ModificarTarea(int idTarea, int idCarpeta, string nombre, string descripcion, DateTime fechaFin, int prioridad)
        {
            Tareas tarea = context.Tareas.Where(e => e.IdTarea == idTarea).FirstOrDefault();
            tarea.IdCarpeta = idCarpeta;
            tarea.Nombre = nombre;
            tarea.Descripcion = descripcion;
            tarea.FechaFin = fechaFin;
            tarea.Prioridad = Convert.ToInt16(prioridad);
            context.SaveChanges();
        }

        public void EliminarTarea(int idTarea)
        {
            var baja = (from e in context.Tareas
                        where e.IdTarea == idTarea
                        select e).Single();

            context.Tareas.DeleteObject(baja);
            context.SaveChanges();
        }

        public Tareas ObtenerTareaModificar(int idTarea)
        {
            Tareas tarea = context.Tareas.Where(e => e.IdTarea == idTarea).FirstOrDefault();
            return tarea;
        }

        public Tareas ObtenerTareaEliminar(int idTarea)
        {
            Tareas tarea = context.Tareas.Single(e => e.IdTarea == idTarea);
            return tarea;
        }
    }
}
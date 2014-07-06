using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;

namespace CAPTasksMVC.Repositorios
{
    public class CarpetaTareaRepositorio
    {
        CAPTasksEntities context = new CAPTasksEntities();

        public CarpetaTareaModel CrearListas()
        {
            var resultCarpetas = (from carpetas in context.Carpetas select carpetas).ToList();


            // Falta en la consulta el usuario logueado
            var resultTareas = (from tareas in context.Tareas
                                join carp in context.Carpetas on tareas.IdCarpeta equals carp.IdCarpeta
                                where tareas.Estado == 1
                                orderby tareas.FechaFin descending
                                select new 
                                {
                                    tareas.IdTarea, tareas.IdUsuario, Carpeta = carp.Nombre, Tarea = tareas.Nombre,
                                    tareas.Descripcion, Fecha = tareas.FechaFin, tareas.Prioridad, tareas.Estado

                                }).ToList();

            List<LecturaTarea> listLecTareas = new List<LecturaTarea>();

            foreach (var lectTareas in resultTareas)
            {
                LecturaTarea lt = new LecturaTarea();

                lt.IdTarea = lectTareas.IdTarea;
                lt.IdUsuario = lectTareas.IdUsuario;
                lt.Carpeta = lectTareas.Carpeta;
                lt.Tarea = lectTareas.Tarea;
                lt.Descripcion = lectTareas.Descripcion;
                lt.Fecha = Convert.ToDateTime(lectTareas.Fecha);

                switch (lectTareas.Prioridad)
                {
                    case 0:
                        lt.Prioridad = "Baja";
                        break;
                    case 1:
                        lt.Prioridad = "Media";
                        break;
                    case 2:
                        lt.Prioridad = "Alta";
                        break;
                    case 3:
                        lt.Prioridad = "Urgente";
                        break;
                }

                switch (lectTareas.Estado)
                {
                    case 0:
                        lt.Estado = "Finalizada";
                        break;
                    case 1:
                        lt.Estado = "En curso";
                        break;
                }

                listLecTareas.Add(lt);

            }

            CarpetaTareaModel carpTarea = new CarpetaTareaModel();

            carpTarea.Carpetas = resultCarpetas;
            carpTarea.Tareas = listLecTareas;

            return carpTarea;
        
        }
    }
}
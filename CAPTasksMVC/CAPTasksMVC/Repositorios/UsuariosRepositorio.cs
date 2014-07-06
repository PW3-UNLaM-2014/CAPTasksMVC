using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;



namespace CAPTasksMVC.Repositorios
{
    public class UsuariosRepositorio
    {

        CAPTasksEntities context = new CAPTasksEntities();
        public void Crear(int idUsuario, string nombre, string descripcion, int idCarpeta, DateTime fechaFin, int prioridad)
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
    }
}
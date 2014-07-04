using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAPTasksMVC.Models;
using CAPTasksMVC.Repositorios;
using System.Web.Mvc;

namespace CAPTasksMVC.Servicios
{
    public class TareasServicios
    {
        TareasRepositorio tr = new TareasRepositorio();
        public void CrearTarea(int idUsuario, string nombre, string descripcion, int idCarpeta, DateTime fechaFin, int prioridad)
        {
            tr.CrearTarea(idUsuario, nombre, descripcion, idCarpeta, fechaFin, prioridad);
        }

        public void ModificarTarea(int idTarea, int idCarpeta, string nombre, string descripcion, DateTime fechaFin, int prioridad)
        {
            tr.ModificarTarea(idTarea, idCarpeta, nombre, descripcion, fechaFin, prioridad);
        }

        public void EliminarTarea(int idTarea)
        {
            tr.EliminarTarea(idTarea);
        }

        public Tareas ObtenerTareaModificar(int idTarea)
        {
            return tr.ObtenerTareaModificar(idTarea);
        }

        public Tareas ObtenerTareaEliminar(int idTarea)
        {
            return tr.ObtenerTareaEliminar(idTarea);
        }
    }
}
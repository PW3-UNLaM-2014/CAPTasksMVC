using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAPTasksMVC.Models;
using CAPTasksMVC.Repositorios;
using System.Web.Mvc;

namespace CAPTasksMVC.Servicios
{
    public class UsuariosServicios
    {
        UsuariosRepositorio tr = new UsuariosRepositorio();
        public void Crear(int idUsuario, string nombre, string descripcion, int idCarpeta, DateTime fechaFin, int prioridad)
        {
            tr.Crear(idUsuario, nombre, descripcion, idCarpeta, fechaFin, prioridad);
        }

    }
}
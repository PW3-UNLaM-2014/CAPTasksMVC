using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAPTasksMVC.Models;

namespace CAPTasksMVC.Repositorios
{
    public class CarpetasRepositorio
    {
        CAPTasksEntities context = new CAPTasksEntities();
        public void CrearCarpeta(Carpetas carpeta)
        {
            //VERSION 1:
            context.AddToCarpetas(carpeta);
            context.SaveChanges();
            //VERSION 2, para capturar idUsuario:
            //Carpetas miCarpeta = new Carpetas();
            //miCarpeta.IdUsuario = idUsuario;
            //miCarpeta.Nombre = nombre;
            //miCarpeta.Descripcion = descripcion;
            //cap.AddToCarpetas(miCarpeta);
        }
    }
}
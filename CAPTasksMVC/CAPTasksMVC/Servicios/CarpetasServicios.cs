using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAPTasksMVC.Models;
using CAPTasksMVC.Repositorios;

namespace CAPTasksMVC.Servicios
{
    public class CarpetasServicios
    {
        CarpetasRepositorio cr = new CarpetasRepositorio();
        
        public void CrearCarpeta(Carpetas carpeta)
        {
            cr.CrearCarpeta(carpeta);
        }
    }
}
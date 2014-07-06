using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAPTasksMVC.Models;
using CAPTasksMVC.Repositorios;

namespace CAPTasksMVC.Servicios
{
    public class CarpetaTareaServicios
    {
        CarpetaTareaRepositorio ctr = new CarpetaTareaRepositorio();

        public CarpetaTareaModel CrearListas()
        {
            CarpetaTareaModel carpTarea;
            carpTarea = ctr.CrearListas();

            return carpTarea;
        }
    }
}
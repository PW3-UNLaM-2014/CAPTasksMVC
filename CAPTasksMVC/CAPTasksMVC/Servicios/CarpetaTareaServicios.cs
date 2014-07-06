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

        public CarpetaTareaModel CrearListas(int idUsuario)
        {
            CarpetaTareaModel carpTarea = ctr.CrearListas(idUsuario);
            return carpTarea;
        }

        public CarpetaTareaModel ListarTareasPorCarpeta(int idCarpeta, int idUsuario)
        {
            CarpetaTareaModel carpTareaTodas = ctr.ListarTareasPorCarpeta(idCarpeta, idUsuario);
            return carpTareaTodas;
        }
    }
}
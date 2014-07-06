﻿using System;
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
            context.AddToCarpetas(carpeta);
            context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPTasksMVC.Models
{
    public class CarpetaTareaModel
    {
        public List<Carpetas> Carpetas { get; set; }
        //public List<Tareas> Tareas { get; set; }
        public List<LecturaTarea> Tareas { get; set; }
    }
}
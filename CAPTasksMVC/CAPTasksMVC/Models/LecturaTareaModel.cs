using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CAPTasksMVC.Models
{
    public class LecturaTarea
    {
        public int IdTarea { set; get; }
        public int IdUsuario { set; get; }
        public string Carpeta { set; get; }
        public string Tarea { set; get; }
        public string Descripcion { set; get; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { set; get; }
        public string Prioridad { set; get; }
        public string Estado { set; get; }
    }
}
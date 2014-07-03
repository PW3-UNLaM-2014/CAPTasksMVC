using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 

namespace CAPTasksMVC.Models
{
    [MetadataType(typeof(TareaModel))]
    public partial class Tareas
    {
        public class TareaModel
        {
            [Required(ErrorMessage="Campo Obligatorio")]
            [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
            public object Nombre { get; set; }

            [DataType(DataType.MultilineText)]
            public object Descripcion { get; set; }

            [Required(ErrorMessage = "Introduzca una fecha valida")]
            [DisplayName("Fecha Finalización")]
            public object FechaFin { get; set; }

        }
    }
}
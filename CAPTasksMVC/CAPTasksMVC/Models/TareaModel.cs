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
        [Bind(Exclude = "IdTarea")]
        public class TareaModel
        {
            [Required(ErrorMessage="Campo Obligatorio")]
            [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
            public string Nombre { get; set; }
            public string Descripcion { set; get; }

            [Required(ErrorMessage = "Introduzca una fecha valida")]
            [DisplayName("Fecha Finalización")]
            [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime FechaFin { set; get; }
            public int Prioridad { set; get; }
            public int Estado { set; get; }

        }
    }
}
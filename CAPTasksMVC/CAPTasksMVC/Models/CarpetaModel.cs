using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 

namespace CAPTasksMVC.Models
{
    [MetadataType(typeof(CarpetaModel))]
    public partial class Carpetas
    {
        public class CarpetaModel
        {      
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
            public object Nombre { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
            [DataType(DataType.MultilineText)]
            public object Descripcion { get; set; }
        }
    }
}
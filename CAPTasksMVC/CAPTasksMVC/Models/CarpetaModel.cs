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
        [Bind(Exclude = "IdCarpeta")]

        public class CarpetaModel
        {
            public int IdCarpeta { get; set; }

            public int IdUsuario { get; set; }

            [Required(ErrorMessage="Campo obligatorio")]
            [StringLength(20,ErrorMessage="Maximo 20 caracteres")]
            public string Nombre { get; set; }

            [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
            public string Descripcion{get;set;}
        }
    }
}
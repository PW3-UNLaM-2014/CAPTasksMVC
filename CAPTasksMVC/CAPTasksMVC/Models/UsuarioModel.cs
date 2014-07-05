using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CAPTasksMVC.Models
{
    [MetadataType(typeof(UsuarioModel))]
    public partial class Usuarios
    {
        public class UsuarioModel
        {
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [Required(ErrorMessage = "Campo Obligatorio")]
            public object Nombre { get; set; }

            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [Required(ErrorMessage = "Campo Obligatorio")]
            [DataType(DataType.Password)]
            public object Contrasenia { get; set; }


            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Apellido { get; set; }

            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Estado { get; set; }
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object FechaCreacion { get; set; }
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object FechaActivacion { get; set; }
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object CodigoActivacion { get; set; }


        }
    }
}
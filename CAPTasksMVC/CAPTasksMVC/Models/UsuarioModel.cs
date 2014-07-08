using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CAPTasksMVC.Models
{
    [MetadataType(typeof(UsuarioModel))]
    public partial class Usuarios
    {
        [DisplayName("Repetir Contraseña")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Compare("Contrasenia", ErrorMessage = "Las contraseñas deben ser iguales")]
        public string ConfirmPassword { get; set; }

        public class UsuarioModel
        {
            [Required(ErrorMessage = "Campo Obligatorio")]
            [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Nombre { get; set; }


            [Required(ErrorMessage = "Campo Obligatorio")]
            [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
            [DataType(DataType.EmailAddress)]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Email { get; set; }

             [DisplayName("Contraseña")]
            [Required(ErrorMessage = "Campo Obligatorio")]
            [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
            [DataType(DataType.Password)]
            [RegularExpression(@"^(?=(.*\d){2})(?=(.*[A-Z]){1}).{0,}$", ErrorMessage = "La contraseña al menos deberá contener 2 números y una letra mayúscula.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Contrasenia { get; set; }

            [Required(ErrorMessage = "Campo Obligatorio")]
            [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
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
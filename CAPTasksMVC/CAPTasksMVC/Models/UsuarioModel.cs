﻿using System;
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
            [Required(ErrorMessage = "Campo Obligatorio")]
            public object Nombre { get; set; }

            [Required(ErrorMessage = "Campo Obligatorio")]
            [DataType(DataType.Password)]
            public object Contrasenia { get; set; }

        }
    }
}
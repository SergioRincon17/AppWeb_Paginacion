using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb_Paginacion.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }
}
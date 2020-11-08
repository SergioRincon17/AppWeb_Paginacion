using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb_Paginacion.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nombre_User { get; set; }
        public string Correo_User { get; set; }
        public string Contraseña_User { get; set; }
        public string Rol_User { get; set; }
        public bool Estado_User { get; set; }
    }
}
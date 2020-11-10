using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb_Paginacion.Models
{
    public class Dispositivo
    {
        public int Id_Dispositivo { get; set; }
        public string Serial { get; set; }
        public string Ruido { get; set; }
        public string FechaHora { get; set; }
        public string Ubicacion { get; set; }
    }
}
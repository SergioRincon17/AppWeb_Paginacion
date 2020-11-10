using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb_Paginacion.Controllers
{
    public class DispositivoTimeController : Controller
    {
        // GET: Time
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadDisp]
        public string getTime(int id)
        {
            try
            {
                var autorizedID = new List<int> { 1, 2, 3 };
                if (!autorizedID.Exists(X => X == id)) throw new Exception("ID no autorizado");
                return DateTime.Now.AddHours(-5).ToString("yyyy-MM-dd HH:mm:ss");

            }
            catch (Exception ex)
            {
                return "ERROR" + ex.Message;
            }
        }
        public string unAuth()
        {
            return "Dispositivo no autorizado";
        }
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadDisp]
        [HttpPost]
        public string setTime(int id, string Datos)
        {

            try
            {
                Negocio.Dispositivo.agregarReporte(id, Datos);
                return "Hora registrada correctamente";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message+"...= "+Datos;
            }
        }

        public string auth(int id)
        {
            try
            {
                var autorizedID = new List<int> { 1, 2, 3 };
                if (!autorizedID.Exists(X => X == id)) throw new Exception("ID no autorizado");

                var IA = new Seguridad.InfoAutenticar();
                IA.id = id;
                IA.ToCoockieDisp(HttpContext.Response);
                return DateTime.Now.AddHours(-5).ToString("yyyy-MM-dd HH:mm:ss");

            }
            catch (Exception ex)
            {
                return "ERROR" + ex.Message;
            }

        }
    }
}

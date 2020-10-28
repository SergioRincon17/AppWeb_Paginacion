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
        [HttpPost]
        public string setTime(int id, string Datos )
        {
                var Indicadror = Negocio.SetTimeDispositivo.setTime(id, Datos);
                return Indicadror;
        }
    }
}

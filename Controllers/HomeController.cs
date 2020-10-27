using AppWeb_Paginacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;

namespace AppWeb_Paginacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(){
            //Adquirir Datos DataBase Con Bliblioteca
            var TemList = new ListaDispositivos();
            TemList.Lista_Dispositivos = new List<Negocio.Dispositivo>();
            TemList.Lista_Dispositivos = Negocio.Adquirir.AdquirirDispositivos(0);
            var CantidadDatosdb = new NumeroDatos();
            CantidadDatosdb.Numero_Datos = TemList.Lista_Dispositivos.Count;
            CantidadDatosdb.Pagina_Actual = 1;
            return View(CantidadDatosdb);
        }
        public JsonResult PedirDatosdb_Home(int id) {
            var TemList = new ListaDispositivos();
            TemList.Lista_Dispositivos = new List<Negocio.Dispositivo>();
            TemList.Lista_Dispositivos = Negocio.Adquirir.AdquirirDispositivos(id);
            return Json(TemList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Pedir_PaginaMax() {
            int Pag_Max = Negocio.Adquirir.Pedir_PaginaMax();
            return Json(Pag_Max/10,JsonRequestBehavior.AllowGet);
        }
    }
}
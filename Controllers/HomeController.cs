using AppWeb_Paginacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Services;

namespace AppWeb_Paginacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(){
            //Adquirir Datos DataBase Con Bliblioteca
            var CantidadDatosdb = new NumeroDatos();
            CantidadDatosdb.Numero_Datos = Negocio.Adquirir.Pedir_PaginaMax("","","","");
            return View(CantidadDatosdb);
        }
        public JsonResult Pedir_PaginaMax(string Informacion) {
            var DatosFiltro = Informacion.Split(new string[] { ";" }, StringSplitOptions.None);
            int Pag_Max = Negocio.Adquirir.Pedir_PaginaMax(DatosFiltro[0], DatosFiltro[1], DatosFiltro[2], DatosFiltro[3]);
            return Json(Pag_Max,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PedirInfoFiltro(int id ,string Informacion) {
            var DatosFiltro = Informacion.Split(new string[] { ";" }, StringSplitOptions.None);
            var TemList = new ListaDispositivos();
            TemList.Lista_Dispositivos = new List<Negocio.Dispositivo>();
            TemList.Lista_Dispositivos = Negocio.Adquirir.AdquirirDispositivosFiltro(id, DatosFiltro[0], DatosFiltro[1], DatosFiltro[2], DatosFiltro[3]);
            return Json(TemList, JsonRequestBehavior.AllowGet);
        }
    }
}
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
            TemList.Lista_Dispositivos = Negocio.Adquirir.AdquirirDispositivos();
            return View(TemList);
        }
        public JsonResult PedirDatosdb() {
            var TemList = new ListaDispositivos();
            TemList.Lista_Dispositivos = new List<Negocio.Dispositivo>();
            TemList.Lista_Dispositivos = Negocio.Adquirir.AdquirirDispositivos();
            return Json(TemList, JsonRequestBehavior.AllowGet);
        }
    }
}
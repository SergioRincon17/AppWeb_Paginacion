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
    public class UserController : Controller
    {
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadUser]
        public ActionResult Registros()
        {
            //Adquirir Datos DataBase Con Bliblioteca
            var CantidadDatosdb = new NumeroDatos();
            var ModeloFiltro = new Negocio.DatosFiltro();
            ModeloFiltro.Serial = "";
            ModeloFiltro.Ruido = "";
            ModeloFiltro.FechaHora = "";
            ModeloFiltro.Ubicacion = "";
            CantidadDatosdb.Numero_Datos = Negocio.Adquirir.Pedir_PaginaMax(ModeloFiltro);
            return View(CantidadDatosdb);
        }
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadUser]
        public ActionResult Grafica()
        {
            return View();
        }
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadUser]
        public JsonResult Pedir_PaginaMax(string Informacion)
        {
            var DatosFiltro = Informacion.Split(new string[] { ";" }, StringSplitOptions.None);
            var ModeloFiltro = new Negocio.DatosFiltro();
            ModeloFiltro.Serial = DatosFiltro[0];
            ModeloFiltro.Ruido = DatosFiltro[1];
            ModeloFiltro.FechaHora = DatosFiltro[2];
            ModeloFiltro.Ubicacion = DatosFiltro[3];
            int Pag_Max = Negocio.Adquirir.Pedir_PaginaMax(ModeloFiltro);
            return Json(Pag_Max, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadUser]
        public JsonResult PedirInfoFiltro(int id, string Informacion)
        {
            var DatosFiltro = Informacion.Split(new string[] { ";" }, StringSplitOptions.None);
            var TemList = new ListaDispositivos();
            TemList.Lista_Dispositivos = new List<Negocio.Dispositivo>();
            var ModeloFiltro = new Negocio.DatosFiltro();
            ModeloFiltro.Serial = DatosFiltro[0];
            ModeloFiltro.Ruido = DatosFiltro[1];
            ModeloFiltro.FechaHora = DatosFiltro[2];
            ModeloFiltro.Ubicacion = DatosFiltro[3];
            TemList.Lista_Dispositivos = Negocio.Adquirir.AdquirirDispositivosFiltro(id, ModeloFiltro);
            return Json(TemList, JsonRequestBehavior.AllowGet);
        }
    }
}
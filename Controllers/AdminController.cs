using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using AppWeb_Paginacion.Models;

namespace AppWeb_Paginacion.Controllers
{
    public class AdminController : Controller
    {
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadAdmin]
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
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadAdmin]
        public ActionResult Grafica()
        {
            return View();
        }
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadAdmin]
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
        [AppWeb_Paginacion.Seguridad.FiltroSeguridadAdmin]
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
        public ActionResult Edit(int id)
        {
            var TemDispositivo = new Negocio.Dispositivo();
            TemDispositivo = Negocio.Dispositivo.SelecDispocitivo(id);
            return View(TemDispositivo);

        }
        [HttpPost]
        public ActionResult Edit(Negocio.Dispositivo TemDispositivo)
        {
            Negocio.Dispositivo.Editar(TemDispositivo);
            return Redirect("~/Admin/Registros");
        }
        public ActionResult Delete(int id)
        {
            Negocio.Dispositivo.Borrar(id);
            return Redirect("~/Admin/Registros");
        }
        public ActionResult ViewUsuarios(){
            var Temlist = new ListaUsuarios();
            Temlist.ListUsuarios = new List<Negocio.Usuario>();
            Temlist.ListUsuarios = Negocio.Usuario.ListaUsuarios();
            return View(Temlist);
        }
        public ActionResult EditarUser(int id){
            var TemUsuario = Negocio.Usuario.SelecUsuario(id);
            return View(TemUsuario);
        }
        [HttpPost]
        public ActionResult EditarUser(Negocio.Usuario TemUsuario) {
            Negocio.Usuario.EditarUser(TemUsuario);
            return Redirect("~/Admin/ViewUsuarios");
        }
        public ActionResult DeleteUser(int id){
            Negocio.Usuario.BorrarUser(id);
            return Redirect("~/Admin/ViewUsuarios");
        }
        [HttpPost]
        public JsonResult PedirInfoFiltroGraf(string Informacion) {
            var DatosFiltro = Informacion.Split(new string[] { ";" }, StringSplitOptions.None);
            var TemList = new ListaDispositivos();
            TemList.Lista_Dispositivos = Negocio.Adquirir.AdquirirDispositivosFiltroGraf(DatosFiltro[0],DatosFiltro[1],DatosFiltro[2],DatosFiltro[3],DatosFiltro[4]);
            return Json(TemList, JsonRequestBehavior.AllowGet);
        }
    }
}


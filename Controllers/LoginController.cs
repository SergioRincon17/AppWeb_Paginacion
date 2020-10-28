using AppWeb_Paginacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb_Paginacion.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VerificarLogin(Usuario usuario)
        {
            bool verificar = Negocio.Adquirir.VerificarUsuario(usuario.Correo, usuario.Contraseña);
            if (verificar == true){
                return Redirect("/Home/Index");
            }
            else {
                return Redirect("Index");
            }
        }
    }
}

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
            bool verificar = Negocio.Usuario.VerificarUsuario(usuario.Correo_User, usuario.Contraseña_User);
            if (verificar == true)
            {
                var IA = new Seguridad.InfoAutenticar();
                IA.ToCoockie(HttpContext.Response);
                return Redirect("/User/Registros");
            }
            else
            {
                return Redirect("Index");
            }
        }        
        public ActionResult CrearUsuario(Negocio.Usuario usuario) {
            Negocio.Usuario.CrearUser(usuario);
            return Redirect("Index");
        }
    }
}

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
            try
            {
                var user = Negocio.Usuario.VerificarUsuario(usuario.Correo_User, usuario.Contraseña_User);
                if (user != null)
                {
                    var IA = new Seguridad.InfoAutenticar();
                    IA.Usuario = user;
                    IA.ToCoockie(HttpContext.Response);
                    if (user.Rol_User == "Usuario")
                        return Redirect("/User/Registros");
                    if (user.Rol_User == "Admin")
                        return Redirect("/Admin/Registros");

                    return Redirect("Index");
                }
                else
                {
                    return Redirect("Index");
                }
            }
            catch (Exception)
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

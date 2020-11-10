using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

namespace AppWeb_Paginacion.Seguridad
{
    public class InfoAutenticar
    {
        private string key = "acIn92Ds";
        public Negocio.Usuario Usuario { get; set; }
        public int id { get; set; }

        private string Encode()
        {
            string TextUser = Json.Encode(Usuario);
            FormsAuthenticationTicket fat = new FormsAuthenticationTicket(
                1,
                Usuario.Nombre_User,
                DateTime.Now,
                DateTime.Now.AddDays(1),
                true,
                TextUser);
            return FormsAuthentication.Encrypt(fat);
        }
        private string EncodeId()
        {
            string TextUser = Json.Encode(id);
            FormsAuthenticationTicket fat = new FormsAuthenticationTicket(
                1,
                id.ToString(),
                DateTime.Now,
                DateTime.Now.AddDays(1),
                true,
                TextUser);
            return FormsAuthentication.Encrypt(fat);
        }
        private void Decode(string Codedinfo)
        {
            FormsAuthenticationTicket fat =
                FormsAuthentication.Decrypt(Codedinfo);
            Usuario = Json.Decode<Negocio.Usuario>(fat.UserData);
        }

        public void ToCoockie(HttpResponseBase httpResponse)
        {
            var expiracion = DateTime.Now.AddDays(1);
            HttpCookie cookie= new HttpCookie(key, Encode());
            cookie.Expires = expiracion;
            httpResponse.Cookies.Add(cookie);
        }
        public int FromCookie(HttpRequestBase httpRequest)
        {
            ///// 0 = no, 1 = user, 2 = admin, 3 = dispositivo, 4 = desconocido
            HttpCookie cookie = httpRequest.Cookies[key];
            if (cookie == null)
                return 0;
            else
            {
                Decode(cookie.Value);
                if (Usuario.Rol_User == "Usuario")
                    return 1;
                else if (Usuario.Rol_User == "Admin")
                    return 2;
                else if (Usuario.Rol_User == "dispositivo")
                    return 3;
                else
                    return 4;
            }
        }

        public void ToCoockieDisp(HttpResponseBase httpResponse)
        {
            var expiracion = DateTime.Now.AddMinutes(1);
            HttpCookie cookie = new HttpCookie(key, EncodeId());
            cookie.Expires = expiracion;
            httpResponse.Cookies.Add(cookie);
        }
        public int FromCookieDisp(HttpRequestBase httpRequest)
        {
            HttpCookie cookie = httpRequest.Cookies[key];
            if (cookie == null)
                return 0;
            return 1;
        }
    }
}
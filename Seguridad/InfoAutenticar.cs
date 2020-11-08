using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb_Paginacion.Seguridad
{
    public class InfoAutenticar
    {
        private string key = "info_usuario";
        public void ToCoockie(HttpResponseBase httpResponse)
        {
            HttpCookie cookie= new HttpCookie(key, "ok");
            httpResponse.Cookies.Add(cookie);
        }
        public bool FromCookie(HttpRequestBase httpRequest)
        {
            HttpCookie cookie = httpRequest.Cookies[key];
            if (cookie == null)
                return false;
            else
                return true;
        }
        public void DeleteCookie()
        {

        }
    }
}
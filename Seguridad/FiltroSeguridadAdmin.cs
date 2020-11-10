using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace AppWeb_Paginacion.Seguridad
{
    public class FiltroSeguridadAdmin : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var IA = new InfoAutenticar();
            var respuesta = IA.FromCookie(filterContext.HttpContext.Request);
            if (respuesta != 2)
                filterContext.Result = new HttpUnauthorizedResult();

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Login/Index", false);
            }
        }
    }
}
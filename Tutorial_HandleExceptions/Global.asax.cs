using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Tutorial_HandleExceptions
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error()
        {

            Exception ex = Server.GetLastError();
            //EXCEPTION ES GENERAL, CAST
            //HTTPEXCEPTION SON DE WEB
            //SI HACEMOS ESTA CONVERSION EXPLICITA, NOS DARA ERROR
            //PREGUNTAMOS SI ES UN TIPO DE EXCEPTION HTTP
            //LANZAR MI EXCEPTION
            //throw new HttpException(901, "Este error...");
            if (ex.GetType() == typeof(HttpException))
            {
                HttpException httpexception = ex as HttpException;
                String accion = "";
                switch (httpexception.GetHttpCode())
                {
                    case 404:
                        accion = "PaginaNoEncontrada";
                        break;
                    case 403: //FORBIDDEN 
                        accion = "ErrorGeneral";
                        break;
                    default:
                        accion = "ErrorGeneral";
                        break;
                }
                Context.ClearError();
                RouteData rutaerror = new RouteData();
                rutaerror.Values.Add("controller", "Error");
                rutaerror.Values.Add("action", accion);
                IController controlador = new ErrorController();
                controlador.Execute(
                    new RequestContext(new HttpContextWrapper(Context), rutaerror));
            }
            //No hace falta el else, si no es httpException ira directamente al error personalizado porque esta custom errors mode on

        }
    }
}

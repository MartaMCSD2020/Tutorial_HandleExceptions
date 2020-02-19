using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tutorial_HandleExceptions.Controllers;

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
            //if (ex.GetType() == typeof(HttpException))
            //{
                HttpException httpexception = ex as HttpException;
                String accion = "";
                if (httpexception.GetHttpCode() == 404)
                {
                    accion = "Error404";
                }
                else
                {
                    accion = "ErrorGeneral";
                }
                Context.ClearError();
                RouteData rutaerror = new RouteData();
                rutaerror.Values.Add("controller", "Error");
                rutaerror.Values.Add("action", accion);
                IController controlador = new ErrorController();
                controlador.Execute(
                    new RequestContext(new HttpContextWrapper(Context), rutaerror));
            //}
            //No hace falta el else, si no es httpException ira directamente al error personalizado porque esta custom errors mode on

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tutorial_HandleExceptions.Filters
{
    //FILTERATTRIBUTE: PERMITE PODER INTERCEPTAR
    //PETICIONES ENTRE VIEW Y CONTROLLERS
    //IEXCEPTIONFILTER: FILTRO PARA INTERCEPTAR EXCEPCIONES
    public class ControlExcepcionesEmpleadosAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //Entrara con las excepciones
            //vamos a preguntar si hemos maejado la excepcion
            if(filterContext.ExceptionHandled == false)
            {
                //Mensaje de la excepcion
                String mensaje = filterContext.Exception.Message;
                String controlador = filterContext.RouteData.Values["controller"].ToString();
                RepositoryHospital repo = new RepositoryHospital();
                //implementar como deseamos tratar
                //el control de errores de la app
                //logging, bbdd
                repo.InsertarExcepcion(mensaje, controlador, DateTime.Now);
                //indicamos a la app que ya hemos controlado la excepcion
                filterContext.ExceptionHandled = true;
                //Vista errorsalarios, haremos la misma
                //redireccion que hemos hecho en seguridad
                //con filter (por ejemplo)
                RouteValueDictionary ruta = new RouteValueDictionary(
                    new
                    {
                        controller = "Empleados",
                        action = "ErrorSalarios"
                    }
                    );
                filterContext.Result = new RedirectToRouteResult(ruta);
            }
        }
    }
}
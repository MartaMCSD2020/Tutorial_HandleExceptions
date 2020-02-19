using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Tutorial_HandleExceptions.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error404
        public ActionResult Error404()
        {
            //Si sabemos el codigo de error se lo indicaremos
            //en la respuesta de la app
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            ViewBag.Mensaje = "Página no encontrada en el Servidor";
            return View();
        }

        // GET: ErrorGeneral
        public ActionResult ErrorGeneral()
        {
            ViewBag.Mensaje = "Ha ocurrido un error cualquiera";
            return View();
        }

    }
}
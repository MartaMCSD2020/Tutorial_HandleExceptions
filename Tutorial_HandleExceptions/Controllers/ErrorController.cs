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
            return View();
        }

        // GET: ErrorGeneral
        public ActionResult ErrorGeneral()
        {
            return View();
        }

    }
}
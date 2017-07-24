using AlquilerVehiculo_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVehiculo.Areas.Administrador.Controllers
{
    public class MainController : Controller
    {
        // GET: Administrador/Main
        public ActionResult Index()
        {
            return View();
        }
    }
}
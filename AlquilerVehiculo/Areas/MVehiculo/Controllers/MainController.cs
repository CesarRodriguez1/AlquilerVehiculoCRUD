using AlquilerVehiculo_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVehiculo.Areas.MVehiculo.Controllers
{
    public class MainController : Controller
    {
        // GET: MModelo/Main
        public ActionResult Index()
        {
            ViewBag.ListadoVehiculo = DAVehiculo.ListadoVehiculo();
            ViewBag.ListadoModelo = DAModelo.ListadoModelo();
            return View();
        }




        ///
        public ActionResult Registro()
        {
            ViewBag.ListadoVehiculo = DAVehiculo.ListadoVehiculo();
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Vehiculo vehiculo)
        {
            //para cargar la data
            bool exito = DAVehiculo.RegistrarVehiculo(vehiculo);

            return RedirectToAction("Index");

        }


        public ActionResult Eliminar(string ID)
        {
            bool exito = DAVehiculo.EliminarVehiculo(ID);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(string ID)
        {
            Vehiculo vehiculo = DAVehiculo.ListadoVehiculo().Where(x => x.CodVehiculo == ID).FirstOrDefault();
            //Marca marca = DAModelo.ListadoMarca().Where(x => x.CodMarca == modelo.CodMarca).FirstOrDefault();
            return View(vehiculo);
        }

        [HttpPost]
        public ActionResult Editar(Vehiculo vehiculo)
        {
            //para cargar la data
            bool exito = DAVehiculo.ActualizarVehiculo(vehiculo);
            return RedirectToAction("Index");

        }

        ////
    }
}
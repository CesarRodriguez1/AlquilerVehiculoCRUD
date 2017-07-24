using AlquilerVehiculo_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVehiculo.Areas.MModelo.Controllers
{
    public class MainController : Controller
    {
        // GET: MModelo/Main
        public ActionResult Index()
        {
            ViewBag.ListadoModelo = DAModelo.ListadoModelo();
            ViewBag.ListadoMarca = DAModelo.ListadoMarca();
            return View();
        }




        ///
        public ActionResult Registro()
        {
            ViewBag.ListadoModelo = DAModelo.ListadoModelo();
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Modelo modelo)
        {
            //para cargar la data
            bool exito = DAModelo.RegistrarModelo(modelo);

            return RedirectToAction("Index");

        }


        public ActionResult Eliminar(string ID)
        {
            bool exito = DAModelo.EliminarModelo(ID);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(string ID)
        {
            Modelo modelo = DAModelo.ListadoModelo().Where(x => x.CodModelo == ID).FirstOrDefault();
            //Marca marca = DAModelo.ListadoMarca().Where(x => x.CodMarca == modelo.CodMarca).FirstOrDefault();
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(Modelo modelo)
        {
            //para cargar la data
            bool exito = DAModelo.ActualizarModelo(modelo);
            return RedirectToAction("Index");

        }

        ////
    }
}
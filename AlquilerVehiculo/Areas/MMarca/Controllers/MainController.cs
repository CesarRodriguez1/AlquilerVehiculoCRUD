using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlquilerVehiculo_DA;

namespace AlquilerVehiculo.Areas.MMarca.Controllers
{
    public class MainController : Controller
    {
        // GET: MMarca/Main
        public ActionResult Index()
        {
            ViewBag.ListadoMarca = DAMarca.ListadoMarca();
            return View();
        }
        public ActionResult Registro()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registro(Marca marca)
        {
            //para cargar la data
            bool exito = DAMarca.RegistrarMarca(marca);
            return RedirectToAction("Index");

        }
        public ActionResult Editar(string ID)
        {
            Marca marca = DAMarca.ListadoMarca().Where(x => x.CodMarca == ID).FirstOrDefault();
            //Marca marca = DAModelo.ListadoMarca().Where(x => x.CodMarca == modelo.CodMarca).FirstOrDefault();
            return View(marca);
        }

        [HttpPost]
        public ActionResult Editar(Marca marca)
        {
            //para cargar la data
            bool exito = DAMarca.ActualizarMarca(marca);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(string ID)
        {
            bool exito = DAMarca.EliminarMarca(ID);
            return RedirectToAction("Index");
        }


    }

}
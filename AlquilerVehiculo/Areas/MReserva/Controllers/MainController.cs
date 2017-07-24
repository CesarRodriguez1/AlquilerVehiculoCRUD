using AlquilerVehiculo_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVehiculo.Areas.MReserva.Controllers
{
    public class MainController : Controller
    {
        // GET: MReserva/Main
        public ActionResult Index()
        {
            ViewBag.ListadoReserva = DAReserva.ListadoReserva();
            ViewBag.ListadoVehiculo = DAVehiculo.ListadoVehiculo();
            ViewBag.ListadoCliente = DAReserva.ListadoCliente();
            return View();
        }



        ///
        public ActionResult Registro()
        {
            ViewBag.ListadoReserva = DAReserva.ListadoReserva();
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Reserva reserva)
        {
            //para cargar la data
            bool exito = DAReserva.RegistrarReserva(reserva);

            return RedirectToAction("Index");

        }


        public ActionResult Eliminar(int ID)
        {
            bool exito = DAReserva.EliminarReserva(ID);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int ID)
        {
            Reserva reserva = DAReserva.ListadoReserva().Where(x => x.CodReserva == ID).FirstOrDefault();
            //Marca marca = DAModelo.ListadoMarca().Where(x => x.CodMarca == modelo.CodMarca).FirstOrDefault();
            return View(reserva);
        }

        [HttpPost]
        public ActionResult Editar(Reserva reserva)
        {
            //para cargar la data
            bool exito = DAReserva.ActualizarReserva(reserva);
            return RedirectToAction("Index");

        }

        ////
    }
}
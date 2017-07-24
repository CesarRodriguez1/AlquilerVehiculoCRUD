using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlquilerVehiculo_DA;
namespace AlquilerVehiculo.Areas.MCliente.Controllers
{
    public class MainController : Controller
    {
        // GET: MCliente/Main
        public ActionResult Index()
        {
            ViewBag.ListadoCliente = DACliente.ListadoCliente();
            return View();
        }
        public ActionResult Registro()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Cliente cliente)
        {
            //para cargar la data
            bool exito = DACliente.RegistrarCliente(cliente);

            return RedirectToAction("Index");

        }
        public ActionResult Editar(string ID)
        {
            Cliente cliente = DACliente.ListadoCliente().Where(x => x.CodCliente == ID).FirstOrDefault();
           
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            
            bool exito = DACliente.ActualizarCliente(cliente);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(string ID)
        {
            bool exito = DACliente.EliminarCliente(ID);
            return RedirectToAction("Index");
        }
    }
}
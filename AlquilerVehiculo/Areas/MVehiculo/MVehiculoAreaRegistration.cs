using System.Web.Mvc;

namespace AlquilerVehiculo.Areas.MVehiculo
{
    public class MVehiculoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MVehiculo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MVehiculo_default",
                "MVehiculo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
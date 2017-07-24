using System.Web.Mvc;

namespace AlquilerVehiculo.Areas.MModelo
{
    public class MModeloAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MModelo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MModelo_default",
                "MModelo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
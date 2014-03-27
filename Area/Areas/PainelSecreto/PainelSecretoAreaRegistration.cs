using System.Web.Mvc;

namespace Area.Areas.PainelSecreto
{
    public class PainelSecretoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PainelSecreto";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PainelSecreto_default",
                "PainelSecreto/{controller}/{action}/{id}",
                new { action = "Index", controller="Comeco", id = UrlParameter.Optional }
            );
        }
    }
}
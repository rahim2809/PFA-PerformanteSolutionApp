using System.Web.Mvc;

namespace PerformanteSolutionAppUI.Areas.ProfessionalUser
{
    public class ProfessionalUserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProfessionalUser";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProfessionalUser_default",
                "ProfessionalUser/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
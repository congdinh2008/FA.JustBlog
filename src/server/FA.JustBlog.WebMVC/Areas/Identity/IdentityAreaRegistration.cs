using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Areas.Identity
{
    public class IdentityAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Identity";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Identity_default",
                "Identity/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
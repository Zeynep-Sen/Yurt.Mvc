using System.Security.Permissions;
using System.Web.Mvc;

namespace Yurt.Mvc.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {Controller="Security", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
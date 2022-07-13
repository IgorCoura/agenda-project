using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agenda.MVC.Constants
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Common = "Common";

        public static SelectListItem[] AllRoles = new SelectListItem[]
        {
           new SelectListItem("Admin", "1"),
           new SelectListItem("Commom", "2"),
        };
    }
}


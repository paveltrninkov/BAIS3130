using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace BAIS3130.Pages
{
    public class LoginModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string User { get; set; }
        [BindProperty]
        public string Pass { get; set; }
        public void OnGet()
        {
            HttpContext.Session.Clear();
        }
        public void OnPost()
        {
            if (User == "Gold" && Pass == "Test")
            {
                HttpContext.Session.SetString("Membership", "Gold");
                HttpContext.Session.SetInt32("LoggedIn", 1);
                Response.Redirect("Index");
            }
            else if (User == "Silver" && Pass == "Test")
            {
                HttpContext.Session.SetString("Membership", "Silver");
                HttpContext.Session.SetInt32("LoggedIn", 1);
                Response.Redirect("Index");
            }
            else if (User == "Bronze" && Pass == "Test")
            {
                HttpContext.Session.SetString("Membershp", "Bronze");
                HttpContext.Session.SetInt32("LoggedIn", 1);
                Response.Redirect("Index");
            }
            else
            {
                Message = "Incorrect Login";
            }
        }
    }
}

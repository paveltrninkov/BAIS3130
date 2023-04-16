using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BAIS3130.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3130.Pages
{
    public class ViewHandicapModel : PageModel
    {
        [BindProperty]
        [Required]
        [Range(0, 999, ErrorMessage = "Member Number cannot be a negative")]
        public int MemberNumber { get; set; }
        [BindProperty]
        public double Handicap { get; set; }
        public void OnGet()
        {
            List<string> NotAllowed = new() { "Finance", "ProShop", "MembershipCommittee"};
            if (HttpContext.Session.GetInt32("LoggedIn") == null || NotAllowed.Contains(HttpContext.Session.GetString("Membership")))
            {
                Response.Redirect("Login");
            }
        }
        public void OnPost()
        {
            CBGC RequestDirector = new();
            Handicap = RequestDirector.ViewHandicap(MemberNumber);
        }
    }
}

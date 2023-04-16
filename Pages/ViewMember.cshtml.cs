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
    public class ViewMemberModel : PageModel
    {
        public bool Member { get; set; }
        public List<Scorecard> MemberScores = new List<Scorecard> { };
        public Member MemberInfo = new Member();
        [BindProperty]
        [Required]
        [Range(0, 999, ErrorMessage = "Member Number cannot be a negative")]
        public int MemberNumber { get; set; }
        
        public void OnGet()
        {
            List<string> NotAllowed = new() {"Clerk", "ProShop", "Finance"};
            if (NotAllowed.Contains(HttpContext.Session.GetString("Membership")))
            {
                Response.Redirect("Login");
            }
            else if (HttpContext.Session.GetString("Membership") == "Finance")
            {
                Member = false;
            }
            else
            {
                CBGC RequestDirector = new();
                MemberScores = RequestDirector.GetMemberScores((int)HttpContext.Session.GetInt32("Number"));
                MemberInfo = RequestDirector.ViewMember((int)HttpContext.Session.GetInt32("Number"));
                Member = true;
            }
        }

        public void OnPost()
        {
            CBGC RequestDirector = new();
            MemberScores = RequestDirector.GetMemberScores(MemberNumber);
            MemberInfo = RequestDirector.ViewMember(MemberNumber);
        }
    }
}

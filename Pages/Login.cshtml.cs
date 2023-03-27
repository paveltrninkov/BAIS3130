using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using BAIS3130.Domain;

namespace BAIS3130.Pages
{
    public class LoginModel : PageModel
    {
        public List<Member> MemberLogins = new();
        public string Message { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
            HttpContext.Session.Clear();
            CBGC RequestDirector = new();
            MemberLogins = RequestDirector.GetMemberLogins();
        }
        public void OnPost()
        {
            CBGC RequestDirector = new();
            MemberLogins = RequestDirector.GetMemberLogins();
            Member LoginMember = new();
            if (!String.IsNullOrEmpty(Username))
            {
                LoginMember = RequestDirector.GetMemberPassword(Username);
            }
            else
            {
                Message = "Username is required";
            }
            if (!String.IsNullOrEmpty(LoginMember.Username))
            {
                if (Password == LoginMember.Password)
                {
                    HttpContext.Session.SetString("Membership", LoginMember.Membership.ToString());
                    HttpContext.Session.SetInt32("LoggedIn", 1);
                    HttpContext.Session.SetInt32("Number", (int)LoginMember.MemberNumber);
                    Response.Redirect("Index");
                }
                else
                {
                    Message = "Password is incorrect";
                }
            }
            else
            {
                Message = "Username is incorrect";
            }
        }
    }
}

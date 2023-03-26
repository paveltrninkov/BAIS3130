using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3130.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3130.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string AlternatePhone { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string PostalCode { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string Shareholder1Signature { get; set; }
        [BindProperty]
        public string Shareholder2Signature { get; set; }
        [BindProperty]
        public string Shareholder1Name { get; set; }
        [BindProperty]
        public string Shareholder2Name { get; set; }
        [BindProperty]
        public DateTime DOB { get; set; }
        [BindProperty]
        public string Signature { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null || HttpContext.Session.GetString("Membership") != "Finance")
            {
                Response.Redirect("Login");
            }
        }
        public void OnPost()
        {
            CBGC RequestDirector = new();
            MembershipApplication RegisterMember = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Email = Email,
                AlternatePhone = AlternatePhone,
                PostalCode = PostalCode,
                Address = Address,
                Shareholder1Signed = String.IsNullOrEmpty(Shareholder1Signature) ? 0 : 1,
                Shareholder2Signed = String.IsNullOrEmpty(Shareholder2Signature) ? 0 : 1,
                DOB = DOB,
                Signed = String.IsNullOrEmpty(Signature) ? 0 : 1,
                Shareholder1Name = Shareholder1Name,
                Shareholder2Name = Shareholder2Name,
                Shareholder1Date = DateTime.Now.Date,
                Shareholder2Date = DateTime.Now.Date,
            };
            RequestDirector.ApplyMembership(RegisterMember);
        }
    }
}

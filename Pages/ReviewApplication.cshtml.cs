using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3130.Domain;
using Microsoft.AspNetCore.Http;

namespace BAIS3130.Pages
{
    public class ReviewApplicationModel : PageModel
    {
        public MembershipApplication Application = new(); 
        [BindProperty]
        public string Submit { get; set; }
        [BindProperty]
        public int ApplicationNumber { get; set; }
        [BindProperty]
        public string Membership { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string AlternatePhone { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string PostalCode { get; set; }
        [BindProperty]
        public DateTime DOB { get; set; }
        [BindProperty]
        public string Shareholder1Name { get; set; }
        [BindProperty]
        public bool Shareholder1Signed { get; set; }

        [BindProperty]
        public DateTime Shareholder1Date { get; set; }
        [BindProperty]
        public string Shareholder2Name { get; set; }
        [BindProperty]
        public bool Shareholder2Signed { get; set; }

        [BindProperty]
        public DateTime Shareholder2Date { get; set; }



        [BindProperty]
        public bool Signed { get; set; }



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
            switch (Submit)
            {
                default:
                    Application = RequestDirector.ViewApplication(ApplicationNumber);
                    FirstName = Application.FirstName;
                    LastName = Application.LastName;
                    Email = Application.Email;
                    Address = Application.Address;
                    Phone = Application.Phone;
                    AlternatePhone = Application.AlternatePhone;
                    DOB = Application.DOB;
                    PostalCode = Application.PostalCode;
                    Shareholder1Date = Application.Shareholder1Date;
                    Shareholder1Name = Application.Shareholder1Name;
                    Shareholder1Signed = Application.Shareholder1Signed == 1 ? true : false;
                    Shareholder2Date = Application.Shareholder2Date;
                    Shareholder2Name = Application.Shareholder2Name;
                    Shareholder2Signed = Application.Shareholder2Signed == 1 ? true : false;
                    break;
                case "Accept":
                    Application = new()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Email = Email,
                        Address = Address,
                        Phone = Phone,
                        AlternatePhone = AlternatePhone,
                        DOB = DOB,
                        PostalCode = PostalCode,
                        Shareholder1Date = Shareholder1Date,
                        Shareholder1Name = Shareholder1Name,
                        Shareholder1Signed = Shareholder1Signed ? 1 : 0,
                        Shareholder2Date = Shareholder2Date,
                        Shareholder2Name = Shareholder2Name,
                        Shareholder2Signed = Shareholder2Signed ? 1: 0
                    };
                    RequestDirector.RegisterApplicant(Application, Membership);
                    break;
                case "Reject":
                    RequestDirector.RejectApplication(ApplicationNumber);
                    break;
            }
        }
    }
}

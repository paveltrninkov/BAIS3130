using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3130.Domain;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BAIS3130.Pages
{
    public class ReviewApplicationModel : PageModel
    {
        public MembershipApplication Application = new(); 
        [BindProperty]
        public string Submit { get; set; }
        [BindProperty]
        [Required]
        public int ApplicationNumber { get; set; }
        [BindProperty]
        public string Membership { get; set; }
        [BindProperty]
        [Required]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        public string LastName { get; set; }
        [BindProperty]
        [Required]
        public string Phone { get; set; }
        [BindProperty]
        public string AlternatePhone { get; set; }
        [BindProperty]
        [Required]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        public string Address { get; set; }
        [BindProperty]
        [Required]
        public string PostalCode { get; set; }
        [BindProperty]
        [Required]
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
        private static int _applicationNumber { get; set; }



        public void OnGet()
        {
            List<string> NotAllowed = new() { "Finance", "Clerk", "ProShop", "Gold", "Silver", "Bronze", "Copper"};
            if (HttpContext.Session.GetInt32("LoggedIn") == null || NotAllowed.Contains(HttpContext.Session.GetString("Membership")))
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
                    Shareholder1Signed = !Application.Shareholder1Signed;
                    Shareholder2Date = Application.Shareholder2Date;
                    Shareholder2Name = Application.Shareholder2Name;
                    Shareholder2Signed = !Application.Shareholder2Signed;
                    Signed = !Application.Signed;
                    _applicationNumber = ApplicationNumber;
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
                        Shareholder1Signed = Shareholder1Signed,
                        Shareholder2Date = Shareholder2Date,
                        Shareholder2Name = Shareholder2Name,
                        Shareholder2Signed = Shareholder2Signed
                    };
                    RequestDirector.RegisterApplicant(Application, Membership);
                    break;
                case "Reject":
                    ApplicationNumber = _applicationNumber;
                    RequestDirector.RejectApplication(_applicationNumber);
                    break;
            }
        }
    }
}

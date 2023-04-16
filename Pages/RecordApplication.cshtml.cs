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
    public class RegisterModel : PageModel
    {
        [BindProperty]
        [Required]
        [StringLength(25, ErrorMessage = "First Name cannot exceed 25 characters")]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        [StringLength(25, ErrorMessage = "Last Name cannot exceed 25 characters")]
        public string LastName { get; set; }
        [BindProperty]
        [Required]
        [StringLength(13, ErrorMessage = "Phone Number cannot exceed 13 characters")]
        public string Phone { get; set; }
        [BindProperty]
        [StringLength(13, ErrorMessage = "Phone Number cannot exceed 13 characters")]
        public string AlternatePhone { get; set; }
        [BindProperty]
        [Required]
        [StringLength(20, ErrorMessage = "Email cannot exceed 20 characters")]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        [StringLength(6, ErrorMessage = "Postal Code cannot exceed 6 characters")]
        public string PostalCode { get; set; }
        [BindProperty]
        [Required]
        [StringLength(30, ErrorMessage = "Address cannot exceed 30 characters")]
        public string Address { get; set; }
        [BindProperty]
        public string Shareholder1Signature { get; set; }
        [BindProperty]
        public string Shareholder2Signature { get; set; }
        [BindProperty]
        [StringLength(50, ErrorMessage = "Shareholder Name cannot exceed 25 characters")]
        public string Shareholder1Name { get; set; }
        [BindProperty]
        [StringLength(50, ErrorMessage = "Shareholder Name cannot exceed 25 characters")]
        public string Shareholder2Name { get; set; }
        [BindProperty]
        public DateTime DOB { get; set; }
        [BindProperty]
        public string Signature { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null || HttpContext.Session.GetString("Membership") != "MembershipCommittee")
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
                Shareholder1Signed = String.IsNullOrEmpty(Shareholder1Signature),
                Shareholder2Signed = String.IsNullOrEmpty(Shareholder2Signature),
                DOB = DOB,
                Signed = String.IsNullOrEmpty(Signature),
                Shareholder1Name = Shareholder1Name,
                Shareholder2Name = Shareholder2Name,
                Shareholder1Date = DateTime.Now.Date,
                Shareholder2Date = DateTime.Now.Date,
            };
            RequestDirector.ApplyMembership(RegisterMember);
        }
    }
}

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
    public class ScheduleStandingTeeTimeModel : PageModel
    {
        [BindProperty]
        public int MemberOne { get; set; }
        [BindProperty]
        public int MemberTwo { get; set; }
        [BindProperty]
        public int MemberThree { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime RequestedTime { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null || HttpContext.Session.GetString("Membership") != "Gold")
            {
                Response.Redirect("Login");
            }
        }
        public void OnPost()
        {
            Group party = new()
            {
                ShareholderName = "Bob Bob",
                ShareholderNumber = 1,
                MemberOne = MemberOne,
                MemberTwo = MemberTwo,
                MemberThree = MemberThree
            };

            StandingTeeTime Request = new()
            {
                RequestedTime = RequestedTime,
                StartDate = StartDate,
                EndDate = EndDate,
                PriorityNumber = 1,
                ApprovedBy = "Henry Roberts",
                ApprovedDate = DateTime.Now
            };

            if (DateTime.Compare(StartDate, EndDate)  < 0)
            {
                CBGC RequestDirector = new();

                if (RequestDirector.RequestStandingTeeTime(party, Request))
                {
                    Message = "Successful";
                }
                else
                {
                    Message = "Scheduling Unsuccessful";
                }
            }
            else
            {
                Message = "End date must be before Start date";
            }


            

        }
    }
}

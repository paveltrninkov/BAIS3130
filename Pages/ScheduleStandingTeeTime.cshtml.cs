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

            StandingTeeTime Request = new()
            {
                ShareholderMemberName = "Bob Bob",
                ShareholderMemberNumber = 1,
                GroupMemberOne = MemberOne,
                GroupMemberTwo = MemberTwo,
                GroupMemberThree = MemberThree,
                RequestedTime = RequestedTime.TimeOfDay.ToString(),
                StartDate = StartDate.Date.ToString(),
                EndDate = EndDate.Date.ToString(),
                PriorityNumber = 1,
                DayOfWeek = StartDate.DayOfWeek.ToString()
            };

            CBGC RequestDirector = new();

            if (RequestDirector.RequestStandingTeeTime(Request))
            {
                Message = "Successful";
            }
            else
            {
                Message = "Fail";
            }

        }
    }
}

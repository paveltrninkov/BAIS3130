using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3130.Domain;

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

            CBGC RequestDirector = new();

            if (RequestDirector.RequestStandingTeeTime(party, Request))
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

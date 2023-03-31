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
        public List<StandingTeeTime> StandingTeeTimes;
        [BindProperty]
        public int StandingTeeTimePos { get; set; }
        [BindProperty]
        public string MemberOne { get; set; }
        [BindProperty]
        public string MemberTwo { get; set; }
        [BindProperty]
        public string MemberThree { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime RequestedTime { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public string Submit { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null || HttpContext.Session.GetString("Membership") != "Gold")
            {
                Response.Redirect("Login");
            }
            else
            {
                CBGC RequestDirector = new();
                StandingTeeTimes = RequestDirector.GetStandingTeeTimesForMember((int)HttpContext.Session.GetInt32("Number"));
            }
        }
        public void OnPost()
        {
            CBGC RequestDirector = new();
            StandingTeeTimes = RequestDirector.GetStandingTeeTimesForMember(int.Parse(HttpContext.Session.GetInt32("Number").ToString()));
            switch (Submit)
            {
                default:

                    CBGC CancelDirector = new();
                    bool Confirmation = CancelDirector.CancelStandingTeeTime(StandingTeeTimes[int.Parse(Submit)].StandingTeeTimeNumber);
                    StandingTeeTimes.Remove(StandingTeeTimes[StandingTeeTimePos]);
                    Response.Redirect("ScheduleStandingTeeTime");
                    if (Confirmation)
                    {
                        Message = "Cancel Successful";
                    }
                    else
                    {
                        Message = "Something went wrong.";
                    }
                    break;
                case "Schedule Standing Tee Time":
                    StandingTeeTime Request = new()
                    {
                        ShareholderMemberName = "Bob Bob",
                        ShareholderMemberNumber = int.Parse(HttpContext.Session.GetInt32("Number").ToString()),
                        GroupMemberOne = MemberOne,
                        GroupMemberTwo = MemberTwo,
                        GroupMemberThree = MemberThree,
                        RequestedTeeTime = RequestedTime.TimeOfDay.ToString(),
                        StartDate = StartDate.Date.ToString(),
                        EndDate = EndDate.Date.ToString(),
                        PriorityNumber = 1,
                        DayOfWeek = StartDate.DayOfWeek.ToString()
                    };
                    if (DateTime.Compare(StartDate, EndDate) < 0)
                    {
                        RequestDirector = new();

                        if (RequestDirector.RequestStandingTeeTime(Request))
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
                    break;
            }
            
        }
    }
}

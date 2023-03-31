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
    public class ScheduleTeeTimeModel : PageModel
    {
        public List<TeeTime> TeeTimes = new();
        [BindProperty]
        public int TeeTimePos { get; set; }
        public string Message { get; set; }
        [BindProperty]
        public DateTime DesiredDate { get; set; }
        [BindProperty]
        public DateTime DesiredTime { get; set; }
        [BindProperty]
        public int MemberOne { get; set; }
        [BindProperty]
        public int MemberTwo { get; set; }
        [BindProperty]
        public int MemberThree { get; set; }
        [BindProperty]
        public int Carts { get; set; }
        [BindProperty]
        public string Submit { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                Response.Redirect("Login");
            } 
        }
        public void OnPost()
        {
            CBGC RequestDirector = new();
            Member TempMember = new()
            {
                Membership = HttpContext.Session.GetString("Membership")
            };
            TimeSpan upperLimit = new();
            TimeSpan lowerLimit = new();
            
            

                if (DateTime.Compare(DesiredDate, DateTime.Now.AddDays(6)) < 0)
                { // 7 days in advance
                    Message = "Must schedule tee time at least 7 days in advance.";
                }
                else
                {
                    switch (TempMember.Membership)
                    {
                        case "Silver": // silver check
                            switch (DesiredDate.DayOfWeek.ToString())
                            {
                                default: // weekday
                                    upperLimit = TimeSpan.Parse("15:00");
                                    lowerLimit = TimeSpan.Parse("17:30");
                                    if (TimeSpan.Compare(DesiredTime.TimeOfDay, upperLimit) < 0 || TimeSpan.Compare(DesiredTime.TimeOfDay, lowerLimit) > 0)
                                    {
                                        SubmitPost();
                                    }
                                    else
                                    {
                                        Message = "Scheduling Unsuccessful";
                                    }
                                    break;
                                case "Saturday": // satuday
                                    lowerLimit = TimeSpan.Parse("11:00");
                                    if (TimeSpan.Compare(DesiredDate.TimeOfDay, lowerLimit) > 0)
                                    {
                                        SubmitPost();
                                    }
                                    else
                                    {
                                        Message = "Scheduling Unsuccessful";
                                    }
                                    break;
                                case "Sunday": // sunday
                                    lowerLimit = TimeSpan.Parse("11:00");
                                    if (TimeSpan.Compare(DesiredDate.TimeOfDay, lowerLimit) > 0)
                                    {
                                        SubmitPost();
                                    }
                                    else
                                    {
                                        Message = "Scheduling Unsuccessful";
                                    }
                                    break;
                            }
                            break;
                        case "Bronze": // bronze check
                            switch (DesiredDate.DayOfWeek.ToString())
                            {
                                default:
                                    upperLimit = TimeSpan.Parse("15:00");
                                    lowerLimit = TimeSpan.Parse("18:00");
                                    if (TimeSpan.Compare(DesiredTime.TimeOfDay, upperLimit) < 0 || TimeSpan.Compare(DesiredTime.TimeOfDay, lowerLimit) > 0)
                                    {
                                        SubmitPost();
                                    }
                                    else
                                    {
                                        Message = "Scheduling Unsuccessful";
                                    }
                                    break;
                                case "Saturday":
                                    lowerLimit = TimeSpan.Parse("13:00");
                                    if (TimeSpan.Compare(DesiredDate.TimeOfDay, lowerLimit) > 0)
                                    {
                                        SubmitPost();
                                    }
                                    else
                                    {
                                        Message = "Scheduling Unsuccessful";
                                    }
                                    break;
                                case "Sunday":
                                    lowerLimit = TimeSpan.Parse("13:00");
                                    if (TimeSpan.Compare(DesiredDate.TimeOfDay, lowerLimit) > 0)
                                    {
                                        SubmitPost();
                                    }
                                    else
                                    {
                                        Message = "Scheduling Unsuccessful";
                                    }
                                    break;
                            }
                            break;
                        case "Gold": // gold
                            SubmitPost();
                            break;
                    }
                }
            }
        private void SubmitPost() // submit post function/method
        {
            CBGC RequestDirector = new();

            TeeTime ScheduledTeeTime = new()
            {
                MemberNumber = (int)HttpContext.Session.GetInt32("Number"),
                DesiredTime = DesiredTime.TimeOfDay,
                DesiredDate = DesiredDate,
                MemberOneID = MemberOne,
                MemberTwoID = MemberTwo,
                NumberOfCarts = Carts,
                MemberThreeID = MemberThree,
                RequestedTime = DateTime.Now.TimeOfDay,
                RequestedDate = DateTime.Now.Date,
                EmployeeName = "Walter Orange"
            };

            if (RequestDirector.BookTeeTime(ScheduledTeeTime))
            {
                Message = "Scheduled Successfully";
            }
            else
            {
                Message = "Scheduling Unsuccessful";
            }
        }
    }
}

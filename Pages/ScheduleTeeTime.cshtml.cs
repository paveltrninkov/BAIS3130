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
        
        public string Message { get; set; }
        [BindProperty]
        public DateTime DesiredDate { get; set; }
        [BindProperty]
        public DateTime DesiredTime { get; set; }
        [BindProperty]
        public int Group { get; set; }
        [BindProperty]
        public int Carts { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                Response.Redirect("Login");
            }
        }
        public void OnPost()
        {
            Member TempMember = new()
            {
                Membership = HttpContext.Session.GetString("Membership")
            };
            TimeSpan upperLimit = new();
            TimeSpan lowerLimit = new();
            
            if (DateTime.Compare(DesiredDate, DateTime.Now.AddDays(7)) < 0){ // 7 days in advance
                Message = "Must schedule tee time at least 7 days in advance.";
            } else
            {
                switch (TempMember.Membership) {
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
                DesiredTime = DesiredDate,
                DesiredDate = DesiredDate,
                NumberOfPlayers = Group,
                NumberOfCarts = Carts,
                RequestedTime = DateTime.Now,
                EmployeeName = "Walter Orange"
            };

            if (RequestDirector.BookTeeTime(ScheduledTeeTime, 1))
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

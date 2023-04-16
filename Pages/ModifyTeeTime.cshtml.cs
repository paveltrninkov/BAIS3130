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
    public class ModifyTeeTimeModel : PageModel
    {
        public List<TeeTime> TeeTimes = new();
        [BindProperty]
        public int MemberOne { get; set; }
        [BindProperty]
        public int MemberTwo { get; set; }
        [BindProperty]
        public int MemberThree { get; set; }
        [BindProperty]
        [Range(0, 4, ErrorMessage = "Cannot have more than 4 carts")] 
        public int NumberOfCarts { get; set; }
        [BindProperty]
        public string Submit { get; set; }
        [BindProperty]
        [Required]
        public string TeeTimeDate { get; set; }
        [BindProperty]
        [Required]
        public string TeeTimeTime { get; set; }
        public int TeeTimePos = 0;
        private static int TeeTimeNumber { get; set; }
        private static int MemberNumber { get; set; }
        public void OnGet()
        {
            MemberNumber = int.Parse(HttpContext.Session.GetInt32("Number").ToString());
            if (HttpContext.Session.GetInt32("LoggedIn") != null)
            {
                CBGC RequestDirector = new();
                TeeTimes = RequestDirector.GetTeeTimesForMember(MemberNumber);
            }
        }
        public void OnPost()
        {
            CBGC RequestDirector = new();
            TeeTimes = RequestDirector.GetTeeTimesForMember(MemberNumber);
            
            if (Submit == "Cancel")
            {
                // delete
                if (ValidatePost())
                {
                    RequestDirector.CancelTeeTime(MemberNumber, TimeSpan.Parse(TeeTimeTime), DateTime.Parse(TeeTimeDate));
                    Response.Redirect("ScheduleTeeTime");
                }
            }
            else if (Submit == "Modify")
            {
                if (ValidatePost())
                {
                    // modify
                    TeeTime ModifiedTeeTime = new()
                    {
                        TeeTimeNumber = TeeTimeNumber,
                        MemberNumber = int.Parse(HttpContext.Session.GetInt32("Number").ToString()),
                        MemberOneID = MemberOne == 0 ? -1 : MemberOne,
                        MemberTwoID = MemberTwo == 0 ? -1 : MemberTwo,
                        MemberThreeID = MemberThree == 0 ? -1 : MemberThree,
                        NumberOfCarts = NumberOfCarts,
                        DesiredDate = DateTime.Parse(TeeTimeDate),
                        DesiredTime = TimeSpan.Parse(TeeTimeTime),
                        RequestedDate = DateTime.Now.Date,
                        RequestedTime = DateTime.Now.TimeOfDay,
                        EmployeeName = "Pavel Trninkov"
                    };
                    RequestDirector.ModifyTeeTime(ModifiedTeeTime);
                }
            }
            else if (Submit == "Check In")
            {
                if (ValidatePost())
                {
                    //Check In
                    RequestDirector.CheckInTeeTime(TeeTimeNumber);
                }
            }
            else
            {
                // find
                TeeTimeNumber = TeeTimes[int.Parse(Submit)].TeeTimeNumber;
                MemberOne = TeeTimes[int.Parse(Submit)].MemberOneID;
                MemberTwo = TeeTimes[int.Parse(Submit)].MemberTwoID;
                MemberThree = TeeTimes[int.Parse(Submit)].MemberThreeID;
                NumberOfCarts = TeeTimes[int.Parse(Submit)].NumberOfCarts;
                TeeTimeDate = TeeTimes[int.Parse(Submit)].DesiredDate.ToString("yyyy-MM-dd");
                TeeTimeTime = DateTime.Parse(TeeTimes[int.Parse(Submit)].DesiredTime.ToString()).ToString("HH:mm");
            }
        }

        public bool ValidatePost()
        {
            bool Valid = true;
            Member TempMember = new()
            {
                Membership = HttpContext.Session.GetString("Membership")
            };
            TimeSpan upperLimit = new();
            TimeSpan lowerLimit = new();



            if (DateTime.Compare(DateTime.Parse(TeeTimeDate), DateTime.Now.AddDays(6)) < 0)
            { // 7 days in advance
                ModelState.AddModelError("Date", "Date cannot exceed 6 days in advance");
            }
            else
            {
                switch (TempMember.Membership)
                {
                    case "Silver": // silver check
                        switch (DateTime.Parse(TeeTimeDate).DayOfWeek.ToString())
                        {
                            default: // weekday
                                upperLimit = TimeSpan.Parse("15:00");
                                lowerLimit = TimeSpan.Parse("17:30");
                                if (TimeSpan.Compare(DateTime.Parse(TeeTimeDate).TimeOfDay, upperLimit) !< 0 || TimeSpan.Compare(DateTime.Parse(TeeTimeDate).TimeOfDay, lowerLimit) !> 0)
                                {
                                    ModelState.AddModelError("TeeTimeDate", "Cannot schedule for that time with your membership level");
                                    Valid = false;
                                }
                                break;
                            case "Saturday": // satuday
                                lowerLimit = TimeSpan.Parse("11:00");
                                if (TimeSpan.Compare(DateTime.Parse(TeeTimeDate).TimeOfDay, lowerLimit) !> 0)
                                {
                                    ModelState.AddModelError("TeeTimeTime", "Cannot schedule for that time with your membership level");
                                    Valid = false;
                                }
                                break;
                            case "Sunday": // sunday
                                lowerLimit = TimeSpan.Parse("11:00");
                                if (TimeSpan.Compare(DateTime.Parse(TeeTimeDate).TimeOfDay, lowerLimit) !> 0)
                                {
                                    ModelState.AddModelError("TeeTimeTime", "Cannot schedule for that time with your membership level");
                                    Valid = false;
                                }
                                break;
                        }
                        break;
                    case "Bronze": // bronze check
                        switch (DateTime.Parse(TeeTimeDate).DayOfWeek.ToString())
                        {
                            default:
                                upperLimit = TimeSpan.Parse("15:00");
                                lowerLimit = TimeSpan.Parse("18:00");
                                if (TimeSpan.Compare(DateTime.Parse(TeeTimeDate).TimeOfDay, upperLimit) !< 0 || TimeSpan.Compare(DateTime.Parse(TeeTimeDate).TimeOfDay, lowerLimit) !> 0)
                                {
                                    ModelState.AddModelError("TeeTimeTime", "Cannot schedule for that time with your membership level");
                                    Valid =  false;
                                }
                                break;
                            case "Saturday":
                                lowerLimit = TimeSpan.Parse("13:00");
                                if (TimeSpan.Compare(DateTime.Parse(TeeTimeDate).TimeOfDay, lowerLimit) !> 0)
                                {
                                    ModelState.AddModelError("TeeTimeTime", "Cannot schedule for that time with your membership level");
                                    Valid = false;
                                }
                                break;
                            case "Sunday":
                                lowerLimit = TimeSpan.Parse("13:00");
                                if (TimeSpan.Compare(DateTime.Parse(TeeTimeDate).TimeOfDay, lowerLimit) !> 0)
                                {
                                    ModelState.AddModelError("TeeTimeTime", "Cannot schedule for that time with your membership level");
                                    Valid = false;
                                }
                                break;
                        }
                        break;
                    case "Gold": // gold
                        Valid = true;
                        break;
                }
            }
            return Valid;
        }
    }
}

using System;
using System.Collections.Generic;
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
        public int NumberOfCarts { get; set; }
        [BindProperty]
        public string Submit { get; set; }
        [BindProperty]
        public string TeeTimeDate { get; set; }
        [BindProperty]
        public string TeeTimeTime { get; set; }
        public int TeeTimePos { get; set; }
        private static int MemberNumber { get; set; }
        private static int TeeTimeNumber { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("LoggedIn") != null)
            {
                CBGC RequestDirector = new();
                TeeTimes = RequestDirector.GetTeeTimesForMember(int.Parse(HttpContext.Session.GetInt32("Number").ToString()));
            }
        }
        public void OnPost()
        {
            CBGC RequestDirector = new();
            TeeTimes = RequestDirector.GetTeeTimesForMember(int.Parse(HttpContext.Session.GetInt32("Number").ToString()));
            if (Submit == "Cancel")
            {
                // delete
                bool Confirmation = RequestDirector.CancelTeeTime(int.Parse(HttpContext.Session.GetInt32("Number").ToString()), TeeTimes[int.Parse(Submit)].DesiredTime, TeeTimes[TeeTimePos].DesiredDate);
                Response.Redirect("ScheduleTeeTime");
            }
            else if (Submit == "Modify")
            {
                // modify
                TeeTime ModifiedTeeTime = new()
                {
                    TeeTimeNumber = TeeTimeNumber,
                    MemberNumber = int.Parse(HttpContext.Session.GetInt32("Number").ToString()),
                    MemberOneID = MemberOne,
                    MemberTwoID = MemberTwo,
                    MemberThreeID = MemberThree,
                    NumberOfCarts = NumberOfCarts,
                    DesiredDate = DateTime.Parse(TeeTimeDate),
                    DesiredTime = TimeSpan.Parse(TeeTimeTime),
                    RequestedDate = DateTime.Now.Date,
                    RequestedTime = DateTime.Now.TimeOfDay,
                    EmployeeName = "Pavel Trninkov"
                };
                bool Confirmation = RequestDirector.ModifyTeeTime(ModifiedTeeTime);
            }
            else
            {
                // find
                TeeTimeNumber = TeeTimes[TeeTimePos].TeeTimeNumber;
                MemberNumber = TeeTimes[TeeTimePos].MemberNumber;
                MemberOne = TeeTimes[TeeTimePos].MemberOneID;
                MemberTwo = TeeTimes[TeeTimePos].MemberTwoID;
                MemberThree = TeeTimes[TeeTimePos].MemberThreeID;
                NumberOfCarts = TeeTimes[TeeTimePos].NumberOfCarts;
                TeeTimeDate = TeeTimes[TeeTimePos].RequestedDate.ToString("MM/dd/yyyy");
                TeeTimeTime = DateTime.Parse(TeeTimes[TeeTimePos].RequestedTime.ToString()).ToString("HH:mm");
            }
        }
    }
}

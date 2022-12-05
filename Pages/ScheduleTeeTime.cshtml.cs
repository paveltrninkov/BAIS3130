using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3130.Domain;

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
        }
        public void OnPost()
        {
            TimeSpan upperLimit = new();
            TimeSpan lowerLimit = new();
            // silver
            if (DateTime.Compare(DesiredDate, DateTime.Now.AddDays(7)) < 0){
                Message = "Must schedule tee time at least 7 days in advance.";
            } else
            {
                switch (DesiredDate.TimeOfDay)
                {
                    default:
                        upperLimit = TimeSpan.Parse("15:00");
                        lowerLimit = TimeSpan.Parse("17:30");
                        if (TimeSpan.Compare(DesiredTime.TimeOfDay, upperLimit) || TimeSpan.Compare())
                        break;
                }
            }
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

            if (RequestDirector.BookTeeTime(ScheduledTeeTime))
            {
                Message = "Scheduled Successfully";
            }
            else
            {
                Message = "Something went wrong.";
            }

        }
    }
}

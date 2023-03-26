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
    public class RecordTeeTimeScoreModel : PageModel
    {
        [BindProperty]
        public int TeeTimeNumber { get; set; }
        [BindProperty]
        public double HandicapIndex { get; set; }
        [BindProperty]
        public int SlopeRating { get; set; }
        [BindProperty]
        public int CourseRating { get; set; }
        [BindProperty]
        public int MemberNumber { get; set; }
        [BindProperty]
        public int Hole1Par { get; set; }
        [BindProperty]
        public int Hole1Score { get; set; }
        [BindProperty]
        public int Hole2Par { get; set; }
        [BindProperty]
        public int Hole2Score { get; set; }
        [BindProperty]
        public int Hole3Par { get; set; }
        [BindProperty]
        public int Hole3Score { get; set; }
        [BindProperty]
        public int Hole4Par { get; set; }
        [BindProperty]
        public int Hole4Score { get; set; }
        [BindProperty]
        public int Hole5Par { get; set; }
        [BindProperty]
        public int Hole5Score { get; set; }
        [BindProperty]
        public int Hole6Par { get; set; }
        [BindProperty]
        public int Hole6Score { get; set; }
        [BindProperty]
        public int Hole7Par { get; set; }
        [BindProperty]
        public int Hole7Score { get; set; }
        [BindProperty]
        public int Hole8Par { get; set; }
        [BindProperty]
        public int Hole8Score { get; set; }
        [BindProperty]
        public int Hole9Par { get; set; }
        [BindProperty]
        public int Hole9Score { get; set; }
        [BindProperty]
        public int Hole10Par { get; set; }
        [BindProperty]
        public int Hole10Score { get; set; }
        [BindProperty]
        public int Hole11Par { get; set; }
        [BindProperty]
        public int Hole11Score { get; set; }
        [BindProperty]
        public int Hole12Par { get; set; }
        [BindProperty]
        public int Hole12Score { get; set; }
        [BindProperty]
        public int Hole13Par { get; set; }
        [BindProperty]
        public int Hole13Score { get; set; }
        [BindProperty]
        public int Hole14Par { get; set; }
        [BindProperty]
        public int Hole14Score { get; set; }
        [BindProperty]
        public int Hole15Par { get; set; }
        [BindProperty]
        public int Hole15Score { get; set; }
        [BindProperty]
        public int Hole16Par { get; set; }
        [BindProperty]
        public int Hole16Score { get; set; }
        [BindProperty]
        public int Hole17Par { get; set; }
        [BindProperty]
        public int Hole17Score { get; set; }
        [BindProperty]
        public int Hole18Par { get; set; }
        [BindProperty]
        public int Hole18Score { get; set; }
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

            int CoursePar = Hole1Par + Hole2Par + Hole3Par + Hole4Par + Hole5Par + Hole6Par + Hole7Par + Hole8Par + Hole9Par + Hole10Par + Hole11Par + Hole12Par + Hole13Par + Hole14Par + Hole15Par + Hole16Par + Hole17Par + Hole18Par;
            double CourseHandicap = (HandicapIndex * (SlopeRating / 113) + (CourseRating - CoursePar));

            Scorecard RecordedScorecard = new()
            {
                TeeTimeNumber = TeeTimeNumber,
                HandicapIndex = HandicapIndex,
                SlopeRating = SlopeRating,
                CourseRating = CourseRating,
                CourseHandicap = CourseHandicap,
                MemberNumber = MemberNumber,
                Hole1Par = Hole1Par,
                Hole1Score = Hole1Score,
                Hole2Par = Hole2Par,
                Hole2Score = Hole2Score,
                Hole3Par = Hole3Par,
                Hole3Score = Hole3Score,
                Hole4Par = Hole4Par,
                Hole4Score = Hole4Score,
                Hole5Par = Hole5Par,
                Hole5Score = Hole5Score,
                Hole6Par = Hole6Par,
                Hole6Score = Hole6Score,
                Hole7Par = Hole7Par,
                Hole7Score = Hole7Score,
                Hole8Par = Hole8Par,
                Hole8Score = Hole8Score,
                Hole9Par = Hole9Par,
                Hole9Score = Hole9Score,
                Hole10Par = Hole10Par,
                Hole10Score = Hole10Score,
                Hole11Par = Hole11Par,
                Hole11Score = Hole11Score,
                Hole12Par = Hole12Par,
                Hole12Score = Hole12Score,
                Hole13Par = Hole13Par,
                Hole13Score = Hole13Score,
                Hole14Par = Hole14Par,
                Hole14Score = Hole14Score,
                Hole15Par = Hole15Par,
                Hole15Score = Hole15Score,
                Hole16Par = Hole16Par,
                Hole16Score = Hole16Score,
                Hole17Par = Hole17Par,
                Hole17Score = Hole17Score,
                Hole18Par = Hole18Par,
                Hole18Score = Hole18Score,
            };

            RequestDirector.RecordScore(RecordedScorecard);

        }
    }
}

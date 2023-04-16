using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3130.Technical_Services;

namespace BAIS3130.Domain
{
    public class CBGC
    {
        public bool BookTeeTime(TeeTime teeTime)
        {
            TeeTimes RequestDirector = new();
            bool confirmation = RequestDirector.ScheduleTeeTime(teeTime);
            return confirmation;
        }

        public bool RequestStandingTeeTime(StandingTeeTime standingTeeTime)
        {
            StandingTeeTimes RequestDirector = new();
            bool confirmation = RequestDirector.ScheduleStandingTeeTime(standingTeeTime);
            return confirmation;
        }

        public List<TeeTime> GetTeeTimesForMember(int memberNumber)
        {
            TeeTimes RequestDirector = new();
            List<TeeTime> returnList = RequestDirector.GetTeeTimesForMembers(memberNumber);
            return returnList;
        }

        public List<StandingTeeTime> GetStandingTeeTimesForMember(int memberNumber)
        {
            StandingTeeTimes RequestDirector = new();
            List<StandingTeeTime> returnList = RequestDirector.GetStandingTeeTimeForMember(memberNumber);
            return returnList;
        }

        public bool CancelStandingTeeTime(int standingTeeTimeNumber)
        {
            bool Confirmation;
            StandingTeeTimes RequestDirector = new();
            Confirmation = RequestDirector.DeleteStandingTeeTime(standingTeeTimeNumber);
            return Confirmation;
        }
        public bool CancelTeeTime(int memberNumber, TimeSpan time, DateTime date)
        {
            TeeTimes RequestDirector = new();
            bool Confirmation = RequestDirector.DeleteTeeTimeForMember(memberNumber, date, time);
            return Confirmation;
        }
        public double ViewHandicap(int memberNumber)
        {
            Members RequestDirector = new();
            double Handicap = RequestDirector.ViewPlayerHandicap(memberNumber);
            return Handicap;
        }
        public bool ApplyMembership(MembershipApplication member)
        {
            Members RequestDirector = new();
            bool Confirmation = RequestDirector.ApplyMembership(member);
            return Confirmation;
        }

        public MembershipApplication ViewApplication(int applicationNumber)
        {
            Members RequestDirector = new();
            MembershipApplication Application = RequestDirector.ViewApplication(applicationNumber);
            return Application;
        }

        public bool RegisterApplicant(MembershipApplication application, string membership)
        {
            Members RequestDirector = new();
            bool Confirmation = RequestDirector.RegisterApplicant(application, membership);
            return Confirmation;
        }
        public bool RejectApplication(int applicationNumber)
        {
            Members RequestDirector = new();
            bool Confirmation = RequestDirector.DeleteApplication(applicationNumber);
            return Confirmation;
        }

        public bool RecordScore(Scorecard scorecard)
        {
            Scorecards RequestDirector = new();
            bool Confirmation = RequestDirector.RecordScorecard(scorecard);
            return Confirmation;
        }

        public Member GetMemberPassword(string username)
        {
            Members RequestDirector = new();
            Member MemberLogin = RequestDirector.GetMemberPassword(username);
            return MemberLogin;
        }
        public List<Member> GetMemberLogins()
        {
            Members RequestDirector = new();
            List<Member> MemberLogins = RequestDirector.GetMemersLogins();
            return MemberLogins;
        }
        public bool ModifyTeeTime(TeeTime updatedTeeTime)
        {
            TeeTimes RequestDirector = new();
            bool Confirmation = RequestDirector.UpdateTeeTime(updatedTeeTime);
            return Confirmation;
        }
        public List<Scorecard> GetMemberScores(int memberNumber)
        {
            Members RequestDirector = new();
            List<Scorecard> MemberScores = RequestDirector.GetMemberScores(memberNumber);
            return MemberScores;
        }
        public Member ViewMember(int memberNumber)
        {
            Members RequestDirector = new();
            Member MemberInfo = RequestDirector.ViewMember(memberNumber);
            return MemberInfo;
        }
        public bool CheckInTeeTime(int teeTimeNumber)
        {
            TeeTimes RequestDirector = new();
            bool Confirmation = RequestDirector.CheckInTeeTime(teeTimeNumber);
            return Confirmation;
        }
    }
}

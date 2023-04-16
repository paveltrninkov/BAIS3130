using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3130.Domain
{
    public class TeeTime
    {
        public int TeeTimeNumber { get; set; }
        public TimeSpan DesiredTime { get; set; }
        public DateTime DesiredDate { get; set; }
        public string FullName { get; set; }
        public int MemberNumber { get; set; }
        public int NumberOfCarts { get; set; }
        public string MemberOne { get; set; }
        public string MemberTwo { get; set; }
        public string MemberThree { get; set; }
        public TimeSpan RequestedTime { get; set; }
        public DateTime RequestedDate { get; set; }
        public string EmployeeName { get; set; }
        public int MemberOneID { get; set; }
        public int MemberTwoID { get; set; }
        public int MemberThreeID { get; set; }
        public bool CheckedIn { get; set; }
    }
}

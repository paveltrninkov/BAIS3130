using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3130.Domain
{
    public class TeeTime
    {
        public DateTime DesiredTime { get; set; }
        public DateTime DesiredDate { get; set; }
        public int MemberNumber { get; set; }
        public int MemberOne { get; set; }
        public int MemberTwo { get; set; }
        public int MemberThree { get; set; }
        public int NumberOfCarts { get; set; }
        public DateTime RequestedTime { get; set; }
        public string EmployeeName { get; set; }
    }
}

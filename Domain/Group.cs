using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3130.Domain
{
    public class Group
    {
        public int ShareholderNumber { get; set; }
        public string ShareholderName { get; set; }
        public int MemberOne { get; set; }
        public int MemberTwo { get; set; }
        public int MemberThree { get; set; }
    }
}

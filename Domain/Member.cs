﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3130.Domain
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Membership { get; set; }
        public string Username { get; set; }
        public double Handicap { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int MemberNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool Signed { get; set; }
        public DateTime DOB { get; set; }
        public string AlternatePhone { get; set; }
    }
}

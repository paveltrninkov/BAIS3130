using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3130.Domain
{
    public class MembershipApplication
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool Signed { get; set; }
        public DateTime DOB { get; set; }
        public string AlternatePhone { get; set; }
        public string Shareholder1Name { get; set; }
        public bool Shareholder1Signed { get; set; }
        public DateTime Shareholder1Date { get; set; }
        public string Shareholder2Name { get; set; }
        public DateTime Shareholder2Date { get; set; }
        public bool Shareholder2Signed { get; set; }
    }
}

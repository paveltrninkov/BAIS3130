using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3130.Domain
{
    public class StandignTeeTime
    {
        public DateTime RequestedTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PriorityNumber { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
    }
}

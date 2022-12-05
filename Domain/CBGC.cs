using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3130.Technical_Services;

namespace BAIS3130.Domain
{
    public class CBGC
    {
        public bool BookTeeTime (TeeTime teeTime)
        {
            TeeTimes RequestDirector = new();
            bool confirmation = RequestDirector.ScheduleTeeTime(teeTime);
            return confirmation;
        }
    }
}

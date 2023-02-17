﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3130.Domain
{
    public class StandingTeeTime
    {
        public int ShareholderMemberNumber { get; set; }
        public string ShareholderMemberName { get; set; }
        public int GroupMemberOne { get; set; }
        public int GroupMemberTwo { get; set; }
        public int GroupMemberThree { get; set; }
        public string DayOfWeek { get; set; }
        public string RequestedTime { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int PriorityNumber { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedTeeTime { get; set; }
    }
}

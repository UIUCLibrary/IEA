using System;
using System.Collections.Generic;

#nullable disable

namespace IllinoisExpertsManualAdditions.Models
{
    public partial class IrcPt05Org
    {
        public int Pt05id { get; set; }
        public string OrgTitle { get; set; }
        public string CampusCd { get; set; }
        public string AdminCd { get; set; }
        public string CollCd { get; set; }
        public string SchoolCd { get; set; }
        public string DeptCd { get; set; }
        public string Organizationid { get; set; }
        public DateTime? Pulldate { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace IllinoisExpertsManualAdditions.Models
{
    public partial class IrcPt1Job
    {
        public int Pt1id { get; set; }
        public string EdwPersId { get; set; }
        public string Uin { get; set; }
        public string PersLname { get; set; }
        public string PersFname { get; set; }
        public string Firstmiddlename { get; set; }
        public string PersMname { get; set; }
        public string JobDetlTitle { get; set; }
        public string JobDetlFte { get; set; }
        public string JobDetlPayPerdSal { get; set; }
        public string JobDetlPosnClsCd { get; set; }
        public string JobDetlEmpeeClsCd { get; set; }
        public string CampusCd { get; set; }
        public string CollCd { get; set; }
        public string SchoolCd { get; set; }
        public string DeptCd { get; set; }
        public string HmCampus { get; set; }
        public string HmDept { get; set; }
        public string Grp { get; set; }
        public string Grpdesc { get; set; }
        public DateTime Pulldate { get; set; }
    }
}

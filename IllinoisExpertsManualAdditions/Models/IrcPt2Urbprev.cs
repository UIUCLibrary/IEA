using System;
using System.Collections.Generic;

#nullable disable

namespace IllinoisExpertsManualAdditions.Models
{
    public partial class IrcPt2Urbprev
    {
        public int Pt2id { get; set; }
        public string EdwPersId { get; set; }
        public string Uin { get; set; }
        public string Appointment { get; set; }
        public string Organization { get; set; }
        public string Startdate { get; set; }
        public string Enddate { get; set; }
        public DateTime? Pulldate { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace IllinoisExpertsManualAdditions.Models
{
    public partial class IrcPt0Faculty
    {
        public int Pt0id { get; set; }
        public int? EdwPersId { get; set; }
        public string Personid { get; set; }
        public string Netid { get; set; }
        public string Profiled { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Ppn { get; set; }
        public string Gender { get; set; }
        public string Visibility { get; set; }
        public string Externallyauthenticated { get; set; }
        public DateTime? Pulldate { get; set; }
    }
}

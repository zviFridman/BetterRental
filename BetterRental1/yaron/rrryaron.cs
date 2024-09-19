using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Workers
    {
        public int Wid { get; set; }

        public string Wfname { get; set; }
        public string Wlname { get; set; }
        public int CompanyCode { get; set; }

        public string WEmail { get; set; }
        public string Wphone { get; set; }
        public string Wadress { get; set; }
        public float SaleryHour { get; set; }
        public float SaleryMonth { get; set; }

        public string Wjob { get; set; }

        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
    }
}
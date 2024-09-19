using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Pay
    {
        public int Paid { get; set; }
        public DateTime Padata { get; set; }
        public float PaySum { get; set; }

        public int Ptid { get; set; }
        public int Caid { get; set; }
        public bool Status { get; set; }
        public int Oid { get; set; }

        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }




        public void Save()
        {
             PayDAL.Save(this);
        }
        public static List<Pay> GetAll()
        {
            return PayDAL.GetAll();
        }
        public static Pay GetById(int Id)
        {
            return PayDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
            return PayDAL.DeleteById(Id);
        }


    }
}
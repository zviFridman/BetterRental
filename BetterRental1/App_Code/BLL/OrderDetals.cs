using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class OrderDetals
    {
        public int Odid { get; set; }
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int CountOD { get; set; }
        public int CountReturn { get; set; }
        public int CountNotUse { get; set; }
        public int Oid { get; set; }
        public int SumProduct { get; set; }

        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }


        public void Save()
        {
             orderDetalsDAL.Save(this);
        }
        public static List<OrderDetals> GetAll()
        {
            return orderDetalsDAL.GetAll();
        }
        public static OrderDetals GetById(int Id)
        {
            return orderDetalsDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
          return   orderDetalsDAL.DeleteById(Id);
        }

    }
}